using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter02.Exercises.Exercise03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Exercise03
{
    [TestClass]
    public class CircleTests
    {
        [DataTestMethod]
        [DataRow(1, Math.PI)]
        [DataRow(2.5, 6.25 * Math.PI)]
        [DataRow(0, 0)]
        public void Space_Returns_Expected(double radius, double expectedSpace)
        {
            var circle = new Circle(radius);

            var space = circle.Space;

            Assert.AreEqual(expectedSpace, space);
        }

        [DataTestMethod]
        [DynamicData(nameof(AddingTwoCirclesExpectations))]
        public void Add_TwoCircles_Returns_CircleWithSpaceOfBoth(Circle circle1, Circle circle2, Circle expectedNewCircle)
        {
            var newCircle = circle1 + circle2;

            Assert.AreEqual(expectedNewCircle.Radius, newCircle.Radius, 0.001);
        }

        public static IEnumerable<object[]> AddingTwoCirclesExpectations
        {
            get
            {
                yield return new object[]{new Circle(0), new Circle(0), new Circle(0)};
                yield return new object[]{new Circle(0.5), new Circle(2), new Circle(2.06155)};
                yield return new object[]{new Circle(3), new Circle(3), new Circle(4.24264) };
            }
        }
    }
}
