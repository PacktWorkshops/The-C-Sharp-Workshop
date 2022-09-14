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
        [DataRow(1, 1, 1, 1, true)]
        [DataRow(1, 2, 1, 1, false)]
        public void Point_Equals_ReturnsTrue_IfValuesAreEqual(int x1, int y1, int x2, int y2, bool expectedAreEqual)
        {
            var p1 = new Point(x1, y1);
            var p2 = new Point(x2, y2);

            var areEqual = p1.Equals(p2);

            Assert.AreEqual(expectedAreEqual, areEqual);
        }

        [DataTestMethod]
        [DataRow(1, 1, 1, 1, 0)]
        [DataRow(0, 0, 3, 4, 5)]
        [DataRow(3, 4, 0, 0, 5)]
        public void DistanceTo_Point_Returns_ExpectedDistance(int x1, int y1, int x2, int y2, double expectedDistance)
        {
            var p1 = new Point(x1, y1);
            var p2 = new Point(x2, y2);

            var distance = p1.DistanceTo(p2);

            Assert.AreEqual(expectedDistance, distance, Tolerance);
        }

        [DataTestMethod]
        [DataRow(1, 1, 1, 1, 0)]
        [DataRow(0, 0, 3, 4, 5)]
        [DataRow(3, 4, 0, 0, 5)]
        public void DistanceBetween_TwoPoints_Returns_ExpectedDistance(int x1, int y1, int x2, int y2, double expectedDistance)
        {
            var p1 = new Point(x1, y1);
            var p2 = new Point(x2, y2);

            var distance = Point.DistanceBetween(p1, p2);

            Assert.AreEqual(expectedDistance, distance, Tolerance);
        }
    }
}
