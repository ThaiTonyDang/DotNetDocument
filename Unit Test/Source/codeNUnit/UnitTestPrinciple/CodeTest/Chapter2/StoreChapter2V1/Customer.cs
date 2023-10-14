using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest.Chapter2.StoreChapter2V1
{
    public class Customer
    {
        public bool Purchase(Store store, Product product, int quantity)
        {
            if (!store.HasEnoughInventory(product, quantity))
            {
                return false;
            }

            store.RemoveInventory(product, quantity);

            return true;
        }
    }
}
