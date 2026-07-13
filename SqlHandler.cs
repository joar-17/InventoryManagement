using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace InventoryManagement
{
    internal class SqlHandler
    {
        static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=inventory;Trusted_Connection=True;Integrated Security=true;";

        static SqlConnection connection = new SqlConnection(connectionString);

        public static void AddProductToDb(Product product)
        {
            string statement = "INSERT INTO products VALUES (@articleNumber, @productName, @price, @quantity)";
            SqlCommand command = new SqlCommand(statement, connection);

            int articleNumber = int.Parse(product.ArticleNumber);

            command.Parameters.AddWithValue("@articleNumber", articleNumber);
            command.Parameters.AddWithValue("@productName", product.Name);
            command.Parameters.AddWithValue("@price", product.Price);
            command.Parameters.AddWithValue("@quantity", product.Quantity);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateProductInDb(Product product)
        {
            string statement = "UPDATE products SET productName = @productName, price = @price, quantity = @quantity WHERE articleNumber = @articleNumber";
            SqlCommand command = new SqlCommand(statement, connection);

            int articleNumber = int.Parse(product.ArticleNumber);

            command.Parameters.AddWithValue("@articleNumber", articleNumber);
            command.Parameters.AddWithValue("@productName", product.Name);
            command.Parameters.AddWithValue("@price", product.Price);
            command.Parameters.AddWithValue("@quantity", product.Quantity);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteProductFromDb(string articleNumber)
        {
            string statement = "DELETE FROM products WHERE articleNumber = @articleNumber";
            SqlCommand command = new SqlCommand(statement, connection);

            int articleNum = int.Parse(articleNumber);

            command.Parameters.AddWithValue("@articleNumber", articleNum);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
