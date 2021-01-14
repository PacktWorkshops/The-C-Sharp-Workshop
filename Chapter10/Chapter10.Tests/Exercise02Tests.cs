using NUnit.Framework;
using Chapter10.Lib;
using System.Collections.Generic;

namespace Chapter10.Tests
{
    [TestFixture]
    public class DeliveryFilterTests
    {

        [Test]
        public void GetSortedMiddleWeightPackages_MultipleItems_ExactOrder()
        {
            // ARRANGE
            var nearPackage = new Package(10_000, 10);
            var midPackage = new Package(20_000, 15);
            var farPackage = new Package(30_000, 20);

            var packages = new List<Package>()
            {
                new Package(100, 20),
                nearPackage,
                new Package(200, 30),
                midPackage,
                new Package(50_000, 1),// far distance but light weight
                farPackage
            };

            var expected = new []
            {
                farPackage, midPackage, nearPackage
            };

            // ACT
            var actual = DeliveryFilters
                .GetSortedMiddleWeightPackages(packages, 3);
            
            // ASSERT
            Assert.That(actual, Is.EqualTo(expected));
        } 
       
       [Test]
        public void GetLastTwoPackages_MultipleItems_ExactOrder()
        {
            // ARRANGE
            var package1 = new Package(20_000, 15);
            var package2 = new Package(30_000, 20);

            var packages = new []
            {
                new Package(100, 1),
                new Package(200, 1),
                new Package(300, 1),
                package1,
                package2
            };

            var expected = new []
            {
                package1, package2
            };

            // ACT
            var actual = DeliveryFilters.GetLastTwoPackages(packages);
            
            // ASSERT
            Assert.That(actual, Is.EqualTo(expected));
        } 
   }
}