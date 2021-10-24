using Chapter02.Exercises.Exercise02;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Exercise03
{
    [TestClass]
    public class RectangleTests
    {
        [DataTestMethod]
        [DataRow(1, 1, 1)]
        [DataRow(2, 0.1, 0.2)]
        [DataRow(3, 2, 6)]
        public void Area_ReturnsExpected(double width, double height, double expectedArea)
        {
            var rectangle = new Rectangle(width, height);

            var area = rectangle.Area;

            Assert.AreEqual(expectedArea, area);
        }
    }
}
