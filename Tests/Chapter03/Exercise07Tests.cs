using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chapter3;

namespace Chapter3UnitTest
{

    [TestClass]
    public class Exercise07Tests
    {
        [TestMethod]
        [DataRow(10D, 5D, CalculatorFactory.Shape.Rectangle, 50D)]
        [DataRow(2D, 10D, CalculatorFactory.Shape.Triangle, 10D)]
        public void GetFactory_Calculate(double a, double b, 
            CalculatorFactory.Shape shape,  double expectedArea)
        {
            var calculator = CalculatorFactory.Get(shape);
            var actualArea = calculator(a, b);
            Assert.AreEqual(expectedArea, actualArea);
        }

    }
}
