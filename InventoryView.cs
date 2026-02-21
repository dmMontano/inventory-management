using System;
using InventoryManagement.Services;

namespace InventoryManagement.Views
{
    public class InventoryView
    {
        private InventoryService _inventoryService;

        public InventoryView()
        {
            _inventoryService = new InventoryService();
        }

        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n=== Inventory Management System ===");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. Reset Inventory");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayInventory();
                        break;
                    case "2":
                        UpdateStock();
                        break;
                    case "3":
                        _inventoryService.ResetInventory();
                        Console.WriteLine("Inventory has been reset.");
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        private void DisplayInventory()
        {
            var products = _inventoryService.GetInventory();

            Console.WriteLine("\nCurrent Inventory:");
            for (int i = 0; i < products.GetLength(1); i++)
            {
                Console.WriteLine($"{i + 1}. {products[0, i]} - Stocks: {products[1, i]}");
            }
        }

        private void UpdateStock()
        {
            DisplayInventory();

            Console.Write("Enter product number to update: ");
            if (int.TryParse(Console.ReadLine(), out int productNumber))
            {
                Console.Write("Enter new stock quantity: ");
                if (int.TryParse(Console.ReadLine(), out int newStock))
                {
                    _inventoryService.UpdateStock(productNumber - 1, newStock);
                    Console.WriteLine("Stock updated successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid stock quantity.");
                }
            }
            else
            {
                Console.WriteLine("Invalid product selection.");
            }
        }
    }
}
