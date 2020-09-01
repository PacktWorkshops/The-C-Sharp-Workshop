using Chapter04;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Chapter04
{
    [TestClass]
    public class InventoryTests
    {
        [TestMethod]
        public void SampleOrdersAreValid()
        {
            var customers = Inventory.GetSampleCustomers();
            var orders = Inventory.GetSampleOrders();
            Assert.IsTrue(orders.All(o => customers.Select(c => c.Id).Contains(o.CustomerId)));
        }
    }
}
