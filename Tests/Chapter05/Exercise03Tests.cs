using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Chapter05;
using Chapter05.Exercise03;

namespace Chapter05UnitTest
{

    class TestSalesLoader : ISalesLoader
    {
        private readonly IEnumerable<CarSale> _carSales;


        public TestSalesLoader(IEnumerable<CarSale> carSales, int delayInSeconds)
        {
            _carSales = carSales;
            DelayInSeconds = delayInSeconds;
        }

        public IEnumerable<CarSale> FetchSales()
        {
            Logger.Log("FetchSales: sleeping...");
            Thread.Sleep(TimeSpan.FromSeconds(DelayInSeconds));
            return _carSales;
        }

        public int DelayInSeconds { get; }
    }

    [TestClass]
    public class Exercise03Tests
    {
        
        [TestMethod]
        public void CalculateAverageWithDelays()
        {
            var northSales = Enumerable.Empty<CarSale>();
            var eastSales = new[]
            {
                new CarSale("Ford", 1000D),
                new CarSale("Audi", 2000D),
                new CarSale("Renault", 3000D),
                new CarSale("BMW", 3000D)
            };
            var southSales = new[]
            {
                new CarSale("Fiat", 500D),
                new CarSale("Tesla", 10000D),
                new CarSale("Mercedes", 8000D)
            };
            var westSales = new[]
            {
                new CarSale("Porsche", 6000D)
            };

            var allSales = new[] 
            {
                northSales, eastSales, 
                southSales, westSales
            };

            var random = new Random();

            var loaders = allSales
                .Select(sales => new TestSalesLoader(sales, random.Next(3)))
                .ToList();

            var expectedAverage = allSales
                .SelectMany(sales => sales)
                .Average(car => car.SalePrice);

            var maxDelay = loaders.Max(ldr => ldr.DelayInSeconds);

            var averageTask = SalesAggregator.Average(loaders);
            var hasCompleted = averageTask.Wait(TimeSpan.FromSeconds(maxDelay + 2D));
            Assert.IsTrue(hasCompleted);

            //var actualAverage = SalesAggregator.Average(loaders).Result;
            var actualAverage = averageTask.Result;
            Assert.AreEqual(expectedAverage, actualAverage);
        }
    }
}

