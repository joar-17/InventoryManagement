using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace InventoryManagement
{
    internal class FileHandler
    {
        public static void Save()
        {
            string jsonProducts = JsonSerializer.Serialize<List<Product>>(Inventory.stock);

            File.WriteAllText("stock.json", jsonProducts);
        }

        public static void Load()
        {
            string loadedFile = File.ReadAllText("stock.json");

            List<Product> loadedProducts = JsonSerializer.Deserialize<List<Product>>(loadedFile);

            Inventory.stock.AddRange(loadedProducts);
        }
    }
}
