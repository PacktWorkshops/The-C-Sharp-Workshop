using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter02.Activities.Activity01;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Exercise03
{
    [TestClass]
    public class SolutionTests
    {
        [DataTestMethod]
        [DynamicData(nameof(AddingTwoCirclesExpectations))]
        public void Add_TwoCircles_Returns_CircleWithSpaceOfBoth(Circle circle1, Circle circle2, double expectedNewRadius)
        {
            var newRadius = Solution.Solve(circle1, circle2);

            Assert.AreEqual(expectedNewRadius, newRadius, 0.001);
        }

        public static IEnumerable<object[]> AddingTwoCirclesExpectations
        {
            get
            {
                yield return new object[] { new Circle(0), new Circle(0), 0 };
                yield return new object[] { new Circle(0.5), new Circle(2), 2.06155 };
                yield return new object[] { new Circle(3), new Circle(3), 4.24264 };
            }
        }
    }
}
