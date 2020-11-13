using System;
using Chapter02.Exercises.Exercise01;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Exercise02
{
    [TestClass]
    public class CircleTests
    {
        [DataTestMethod]
        [DataRow(1, Math.PI )]
        [DataRow(2, Math.PI * 4)]
        [DataRow(0.5, Math.PI * 0.25)]
        public void Space_ReturnsExpected(double radius, double expectedSpace)
        {
            var circle = new Circle(radius);

            var space = circle.Space;

            Assert.AreEqual(expectedSpace, space);
        }
    }
}
