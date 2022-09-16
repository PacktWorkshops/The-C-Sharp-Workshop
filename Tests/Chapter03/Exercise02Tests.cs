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
                JourneyTime = 10
            };

            var carToday = new Car
            {
                Distance = 50,
                JourneyTime = 6
            };

            var comparer = new JourneyComparer();
            comparer.Compare(carYesterday, carToday);

            Assert.AreEqual(carYesterday.Distance - carToday.Distance,
                comparer.Distance.Difference);

            Assert.AreEqual(carYesterday.JourneyTime - carToday.JourneyTime,
                comparer.JourneyTime.Difference);

            Assert.AreEqual(carYesterday.JourneyTime - carToday.JourneyTime,
                comparer.JourneyTime.Difference);

            var expectedAvgSpeedDiff =
                (carYesterday.Distance / carYesterday.JourneyTime) -
                (carToday.Distance / carToday.JourneyTime);

            Assert.AreEqual(expectedAvgSpeedDiff, comparer.AverageSpeed.Difference);

        }
    }
}