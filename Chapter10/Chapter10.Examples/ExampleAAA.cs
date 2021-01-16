using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Chapter10.Examples
{
    class Order
    {
        public double Total { get; set; }
        public void ApplyDiscount(double amount)
        {}
    }

    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void ApplyDiscount_FityPercent_UpdatesTotal()
        {
            // Arrange
            var order = new Order {Total = 20};
            
            // Act
            order.ApplyDiscount(0.5D);

            // Assert
            Assert.That(order.Total, Is.EqualTo(10));
        }
    }
}
