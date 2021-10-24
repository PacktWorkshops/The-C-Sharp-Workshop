using System;
using Chapter02.Exercises.Exercise02;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Exercise03
{
    [TestClass]
    public class CircleTests
    {
        [DataTestMethod]
        [DataRow(1, Math.PI )]
        [DataRow(2, Math.PI * 4)]
        [DataRow(0.5, Math.PI * 0.25)]
        public void Area_ReturnsExpected(double radius, double expectedArea)
        {
            var circle = new Circle(radius);

            var area = circle.Area;

            Assert.AreEqual(expectedArea, area);
        }
    }
}
