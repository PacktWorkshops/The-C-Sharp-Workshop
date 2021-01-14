using System.Collections.Generic;
using Chapter02.Examples.CsharpKeywords.Struct;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Examples.Struct
{
    [TestClass]
    public class PointTests
    {
        private const double Tolerance = 0.001;

        [DataTestMethod]
        [DynamicData(nameof(EqualityExpectations))]
        public void Point_Equals_ReturnsTrue_IfValuesAreEqual(Point p1, Point p2, bool expectedAreEqual)
        {
            var areEqual = p1.Equals(p2);

            Assert.AreEqual(expectedAreEqual, areEqual);
        }

        [DataTestMethod]
        [DynamicData(nameof(DistanceExpectations))]
        public void DistanceTo_Point_Returns_ExpectedDistance(Point p1, Point p2, double expectedDistance)
        {
            var distance = p1.DistanceTo(p2);

            Assert.AreEqual(expectedDistance, distance, Tolerance);
        }

        [DataTestMethod]
        [DynamicData(nameof(DistanceExpectations))]
        public void DistanceBetween_TwoPoints_Returns_ExpectedDistance(Point p1, Point p2, double expectedDistance)
        {
            var distance = Point.DistanceBetween(p1, p2);

            Assert.AreEqual(expectedDistance, distance, Tolerance);
        }

        public static IEnumerable<object[]> EqualityExpectations
        {
            get
            {
                yield return new object[]{new Point(1,1), new Point(1,1), true};
                yield return new object[]{new Point(1,2), new Point(1,1), false};
            }
        }

        public static IEnumerable<object[]> DistanceExpectations
        {
            get
            {
                yield return new object[]{new Point(1,1), new Point(1,1), 0};
                yield return new object[] {new Point(0, 0), new Point(3, 4), 5};
                yield return new object[] {new Point(3, 4), new Point(0, 0), 5};
            }
        }
    }
}
