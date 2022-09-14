using System.Collections.Generic;
using Chapter02.Activities.Activity01;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Activity01
{
    [TestClass]
    public class SolutionTests
    {
        [DataTestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(0.5, 2, 2.06155)]
        [DataRow(3, 3, 4.24264)]
        public void Add_TwoCircles_Returns_CircleWithAreaOfBoth(double radius1, double radius2, double expectedNewRadius)
        {
            var circle1 = new Circle(radius1);
            var circle2 = new Circle(radius2);

            var newRadius = (circle1 + circle2).Radius;

            Assert.AreEqual(expectedNewRadius, newRadius, 0.001);
        }
    }
}
