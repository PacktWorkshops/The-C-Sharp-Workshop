using Chapter03.Exercise02;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter03
{
    [TestClass]
    public class Exercise02Tests
    {
        [TestMethod]
        public void JourneyComparer()
        {
            var carYesterday = new Car
            {
                Distance = 120,
                FuelUsed = 10
            };

            var carToday = new Car
            {
                Distance = 50,
                FuelUsed = 6
            };

            var comparer = new JourneyComparer();
            comparer.Compare(carYesterday, carToday);

            Assert.AreEqual(carYesterday.Distance - carToday.Distance,
                comparer.Distance.Difference);

            Assert.AreEqual(carYesterday.FuelUsed - carToday.FuelUsed,
                comparer.FuelUsed.Difference);

            Assert.AreEqual(carYesterday.FuelUsed - carToday.FuelUsed,
                comparer.FuelUsed.Difference);

            var expectedEconomyDiff =
                (carYesterday.Distance / carYesterday.FuelUsed) -
                (carToday.Distance / carToday.FuelUsed);

            Assert.AreEqual(expectedEconomyDiff, comparer.FuelEconomy.Difference);

        }
    }
}