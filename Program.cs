using InventoryManagement;
using System.Collections;
using System.Text.Json;


FileHandler.Load();

while (true)
{
    Console.Write("---------MENU--------- \n0 - Exit \n1 - Add/Update product \n2 - Delete product \n3 - View product \n4 - Generate report \n");

    string input = Console.ReadLine();

    if (input == "0")
    {
        break;
    }

    string articleNumber;

    switch (input)
    {
        case "1":
            Console.Write("Enter articlenumber: ");
            articleNumber = Console.ReadLine();

            if (Inventory.stock.Any(obj => obj.ArticleNumber == articleNumber))
            {
                Inventory.UpdateProduct(articleNumber);
            }
            else
            {
                Inventory.AddProduct(articleNumber);
            }
            break;
        case "2":
            Console.Write("Enter articlenumber: ");
            articleNumber = Console.ReadLine();
            if (Inventory.stock.Any(obj => obj.ArticleNumber == articleNumber))
            {
                Inventory.DeleteProduct(articleNumber);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No such product exists");
                Console.ResetColor();
            }
            break;
        case "3":
            Inventory.Print();
            break;
        case "4":
            Inventory.GenerateReport();
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input");
            Console.ResetColor();
            break;
    }
}
