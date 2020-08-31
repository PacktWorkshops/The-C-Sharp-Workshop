using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Chapter3;

namespace Chapter3UnitTest
{
    [TestClass]
    public class Exercise02Tests
    {
        [TestMethod]
        public void ModelDifferencesCompare()
        {
            var greeksYesterday = new Greeks
            {
                Delta = 10D,
                Gamma = 0.25D,
            };

            var greeksToday = new Greeks
            {
                Delta = 15D,
                Gamma = 0.40D
            };

            var pricesYesterday = new Prices { Close = 1.5D };
            var pricesToday = new Prices { Close = 2.0D };

            var diffs = new ModelDifferences();
            diffs.Compare(greeksYesterday, greeksToday,
                pricesYesterday, pricesToday);

            Assert.AreEqual(greeksYesterday.Delta - greeksToday.Delta,
                diffs.Delta.Difference);

            var difGamma = (greeksYesterday.Gamma * 100) -
                           (greeksToday.Gamma * 100D);
            Assert.AreEqual(difGamma, diffs.Gamma.Difference);

            Assert.AreEqual(pricesYesterday.Close - pricesToday.Close,
                diffs.Close.Difference);
        }
    }
}