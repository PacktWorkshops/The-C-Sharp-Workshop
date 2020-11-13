using Chapter02.Exercises.Exercise01;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Exercise02
{
    [TestClass]
    public class RectangleTests
    {
        [DataTestMethod]
        [DataRow(1, 1, 1)]
        [DataRow(2, 0.1, 0.2)]
        [DataRow(3, 2, 6)]
        public void Space_ReturnsExpected(double width, double height, double expectedSpace)
        {
            var rectangle = new Rectangle(width, height);

            var space = rectangle.Space;

            Assert.AreEqual(expectedSpace, space);
        }
    }
}
