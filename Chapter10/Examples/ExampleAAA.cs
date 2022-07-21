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
        public void ApplyDiscount_FiftyPercent_UpdatesTotal()
        {
            // Arrange
            var order = new Order {Total = 20};
            
            // Act
            order.ApplyDiscount(0.5);

            // Assert
            Assert.That(order.Total, Is.EqualTo(10));
        }
    }
}
