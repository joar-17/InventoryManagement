using InventoryManagement;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace InventoryManagement
{
    internal class Inventory
    {
        public static List<Product> stock = new List<Product>();

        public static void AddProduct(string articleNumber)
        {
            try
            {
                Console.Write("Enter a name for the product: ");
                string name = Console.ReadLine();

                Console.Write("Enter the price (per/piece): ");
                int price = int.Parse(Console.ReadLine());

                Console.Write("Enter quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Console.Write($"\nName: {name} \nPrice: {price} \nQuantity: {quantity} \n\nPress Enter to confirm or enter cancel ");
                if (Console.ReadLine() != "cancel")
                {
                    Product product = new Product(articleNumber, name, price, quantity);
                    stock.Add(product);
                    FileHandler.Save();
                    SqlHandler.AddProductToDb(product);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Product has been added \n");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Process cancelled \n");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        public static void UpdateProduct(string articleNumber)
        {
            try
            {
                Product product = stock.First(obj => obj.ArticleNumber == articleNumber);

                Console.Write("Enter new name or press enter to skip: ");
                string name = Console.ReadLine().Trim();

                Console.Write("Please new the price (per/piece) or press enter to skip: ");
                bool convertable = int.TryParse(Console.ReadLine(), out int price);

                Console.Write("To change quantity enter add or subtract or press Enter to skip: ");
                string arithmetic = Console.ReadLine();

                int term = 0;

                if (arithmetic == "add" || arithmetic == "subtract")
                {
                    Console.Write("Enter quantity: ");
                    term = int.Parse(Console.ReadLine());
                }

                Console.Write("Press Enter to confirm changes or enter cancel ");
                if (Console.ReadLine() != "cancel")
                {

                    if (name.Trim() != "")
                    {
                        product.Name = name;
                    }

                    if (convertable)
                    {
                        product.Price = price;
                    }

                    if (arithmetic == "add")
                    {
                        product.Quantity += term;
                    }
                    else if (arithmetic == "subtract" && product.Quantity >= term)
                    {
                        product.Quantity -= term;
                    }
                    else if (arithmetic == "subtract" && product.Quantity < term)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Stock can't be negative \n");
                        Console.ResetColor();
                        return;
                    }

                    FileHandler.Save();
                    SqlHandler.UpdateProductInDb(product);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Updates completed \n");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Process cancelled \n");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        public static void DeleteProduct(string articlenumber)
        {
            try
            {
                Console.Write("Press Enter to delete or enter cancel ");
                string desicion = Console.ReadLine();

                if (desicion != "cancel")
                {
                    Product product = stock.FirstOrDefault(obj => obj.ArticleNumber == articlenumber);
                    stock.Remove(product);
                    FileHandler.Save();
                    SqlHandler.DeleteProductFromDb(articlenumber);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Product removed \n");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Process cancelled \n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Print()
        {
            try
            {
                Console.Write("To show complete list press Enter \nTo search for a specific product enter articlenumber of product name \n");
                string input = Console.ReadLine();

                if (input.Trim() != "")
                {
                    Product product = stock.FirstOrDefault(obj => obj.ArticleNumber == input || obj.Name == input);

                    if (product == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No products found");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("----------------------------------------------------------------");
                        Console.WriteLine("Articlenumber".PadRight(15) + " | " + "Name".PadRight(20) + " | " + "Price ($)".PadRight(10) + " | " + "Quanity");
                        Console.WriteLine("----------------------------------------------------------------");
                        Console.WriteLine($"{product.ArticleNumber.PadRight(15)} | {product.Name.PadRight(20)} | {product.Price.ToString().PadRight(10)} | {product.Quantity}");
                    }
                }
                else
                {
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("Articlenumber".PadRight(15) + " | " + "Name".PadRight(20) + " | " + "Price ($)".PadRight(10) + " | " + "Quanity");
                    Console.WriteLine("----------------------------------------------------------------");

                    foreach (Product product in stock)
                    {
                        Console.WriteLine($"{product.ArticleNumber.PadRight(15)} | {product.Name.PadRight(20)} | {product.Price.ToString().PadRight(10)} | {product.Quantity}");
                    }

                    Console.WriteLine("----------------------------------------------------------------");

                }

                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }

        public static void GenerateReport()
        {
            int totalValue = 0;
            int totalLevels = 0;
            foreach (Product product in stock)
            {
                totalValue += product.Price * product.Quantity;
            }

            foreach (Product product in stock)
            {
                totalLevels += product.Quantity;
            }

            Console.WriteLine();
            Console.WriteLine($"Total levels: {totalLevels} pieces");
            Console.WriteLine($"Total value: {totalValue} $");
            Console.WriteLine();
        }
    }
}
