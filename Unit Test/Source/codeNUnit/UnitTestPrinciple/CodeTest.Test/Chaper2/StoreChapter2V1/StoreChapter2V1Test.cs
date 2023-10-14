using CodeTest.Chapter2.StoreChapter2V1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest.Test.Chaper2.StoreChapter2V1
{
    [TestFixture]
    public class StoreChapter2V1Test
    {
        private Store store;
        private Customer customer;

        [SetUp]
        public void SetUp()
        {
            this.store = new Store();
            this.customer = new Customer();
        }

        [TestCase]
        public void Purchase_succeeds_when_enough_inventory()
        {
            // Arrange
            store.AddInventory(Product.Shampoo, 10);

            // Act
            bool success = customer.Purchase(store, Product.Shampoo, 5);

            // Assert
            Assert.True(success);
            Assert.AreEqual(5, store.GetInventory(Product.Shampoo));
        }

        [TestCase]
        public void Purchase_fails_when_not_enough_inventory()
        {
            // Arrange
            store.AddInventory(Product.Shampoo, 10);

            // Act
            bool success = customer.Purchase(store, Product.Shampoo, 15);

            // Assert
            Assert.False(success);
            Assert.AreEqual(10, store.GetInventory(Product.Shampoo));
        }
    }
}
