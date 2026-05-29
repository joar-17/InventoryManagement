# Inventory Management System

A simple console-based inventory management system written in C#. The application allows users to add, update, delete, and view products, as well as generate inventory reports.

## Features

- Add new products
- Update existing products
- Delete products
- View all products in inventory
- Generate inventory reports
- Automatically load saved data when the program starts

---

## Menu

When the program starts, the following menu is displayed:

```text
---------MENU---------
0 - Exit
1 - Add/Update product
2 - Delete product
3 - View product
4 - Generate report
```

### Options

| Option | Description |
|--------|-------------|
| 0 | Exit the program |
| 1 | Add or update a product |
| 2 | Delete a product |
| 3 | View all products |
| 4 | Generate a report |

---

## How the Program Works

### Add or Update Product

When the user enters an article number:

- If the product already exists, it will be updated
- If the product does not exist, a new product will be created

### Delete Product

The program searches for the entered article number:

- If the product exists, it will be removed
- If the product does not exist, an error message is displayed

### View Products

Displays all products currently stored in the inventory.

### Generate Report

Creates a report based on the current inventory data.

---

## Project Structure

Example of classes used in the project:

```text
Program.cs
Inventory.cs
FileHandler.cs
Product.cs
```

### Main Components

- `FileHandler.Load()`  
  Loads saved inventory data when the program starts.

- `Inventory.stock`  
  Stores all products in the inventory.

- `Inventory.AddProduct()`  
  Adds a new product.

- `Inventory.UpdateProduct()`  
  Updates an existing product.

- `Inventory.DeleteProduct()`  
  Removes a product.

- `Inventory.Print()`  
  Displays all products or allows user to search for product.

- `Inventory.GenerateReport()`  
  Generates an inventory report.

---

## Requirements

- .NET 6.0 or later
- Visual Studio or any compatible C# IDE

---

## Running the Program

1. Clone or download the project files
2. Open the project in Visual Studio
3. Run the application

Or use the terminal:

```bash
dotnet run
```

---

## Author

Created as a simple inventory management project in C#.
