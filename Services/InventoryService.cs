using System;

namespace InventoryManagement.Services
{
    public class InventoryService
    {
        private string[,] products;
        private int[] initialStock;

        public InventoryService()
        {
            products = new string[2, 3]
            {
                { "Apples", "Milk", "Bread" },   
                { "10", "5", "20" }              
            };

            initialStock = new int[3];

            for (int i = 0; i < 3; i++)
            {
                initialStock[i] = int.Parse(products[1, i]);
            }
        }

        public string[,] GetInventory()
        {
            return products;
        }

        public void UpdateStock(int productIndex, int newStock)
        {
            if (productIndex >= 0 && productIndex < 3)
            {
                products[1, productIndex] = newStock.ToString();
            }
        }

        public void ResetInventory()
        {
            for (int i = 0; i < 3; i++)
            {
                products[1, i] = initialStock[i].ToString();
            }
        }
    }
}
