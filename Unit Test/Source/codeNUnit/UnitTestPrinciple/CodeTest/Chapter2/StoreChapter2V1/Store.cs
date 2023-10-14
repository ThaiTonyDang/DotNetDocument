using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest.Chapter2.StoreChapter2V1
{
    public class Store
    {
        private readonly Dictionary<Product, int> _inventory = new Dictionary<Product, int>();

        public void AddInventory(Product product, int quantity)
        {
            if (_inventory.ContainsKey(product))
            {
                _inventory[product] += quantity;
            }
            else
            {
                _inventory.Add(product, quantity);
            }
        }

        public void RemoveInventory(Product product, int quantity)
        {
            if (!HasEnoughInventory(product, quantity))
            {
                throw new Exception("Not enough inventory");
            }

            _inventory[product] -= quantity;
        }

        public int GetInventory(Product product)
        {
            bool productExists = _inventory.TryGetValue(product, out int remaining);
            return productExists ? remaining : 0;
        }

        public bool HasEnoughInventory(Product product, int quantity)
        {
            return GetInventory(product) >= quantity;
        }
    }
}
