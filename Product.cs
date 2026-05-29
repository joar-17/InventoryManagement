using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace InventoryManagement
{
    internal class Product
    {
        public string ArticleNumber { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public Product(string articleNumber, string name, int price, int quantity)
        {
            ArticleNumber = articleNumber;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
