using System;
using System.Collections.Generic;
using Chapter06.Exercises.Exercise05;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter06.Exercises.Exercise03
{
    [TestClass]
    public class ProductTets
    {
        [TestMethod]
        public void GetPrice_GivenMultiplePrices_ReturnsLatest()
        {
            var product = new Product
            {
                PriceHistory = new List<ProductPriceHistory>
                {
                    new()
                    {
                        DateOfPrice = DateTime.Now.AddDays(-1),
                        Price = 5
                    },
                    new()
                    {
                        DateOfPrice = DateTime.Now,
                        Price = 4
                    },
                    new()
                    {
                        DateOfPrice = DateTime.Now.AddDays(-0.5),
                        Price = 3
                    },
                }
            };
            const decimal expectedCurrentPrice = 4;

            var price = product.GetPrice();

            Assert.AreEqual(expectedCurrentPrice, price);
        }
    }
}
