using NUnit.Framework;
using Chapter10.Lib;

namespace Chapter10.Tests
{
    [TestFixture]
    public class DeliveryCalculatorTests
    {
        [TestCase(0)]
        [TestCase(5)]
        public void GetCost_Envelope_DistanceEqualsCost(int distance)
        {
            var envelope = new Envelope(distance);
            var actualCost = DeliveryCalculator.GetCost(envelope);
            Assert.That(actualCost, Is.EqualTo(distance));
        } 
       
        [Test]
        public void GetCost_LightPackage_ProductOfDistance(
            [Random(0, 100, 5)]int distance,
            [Random(0, 9, 5)]int weight)
        {
            var package = new Package(distance, weight);
            var actualCost = DeliveryCalculator.GetCost(package);
            var expectedCost = distance * 2;
            Assert.That(actualCost, Is.EqualTo(expectedCost));
        } 

        [Test]
        public void GetCost_HeavyPackage_ProductOfDistance(
            [Values(100, 200, 300)]int distance, 
            [Values(10, 20)]int weight)
        {
            var package = new Package(distance, weight);
            var actualCost = DeliveryCalculator.GetCost(package);
            var expectedCost = distance * 3;
            Assert.That(actualCost, Is.EqualTo(expectedCost));
        }

        [TestCase(false, 4.0)]
        [TestCase(true, 6.0)]
        public void GetCost_Meal_FixedCost(
            bool isHot,
            double expectedCost)
        {
            var meal = new Meal(isHot);
            var actualCost = DeliveryCalculator.GetCost(meal);
            Assert.That(actualCost, Is.EqualTo(expectedCost));
        }

        [Test]
        public void GetCost_UnknownType_ThrowsException()
        {
            Assert.Throws<System.ArgumentException>( () => 
              { 
                DeliveryCalculator.GetCost(new object());
              });
        }
    }
}