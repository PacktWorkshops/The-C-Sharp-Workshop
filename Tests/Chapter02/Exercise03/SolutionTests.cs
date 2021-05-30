using System.Collections.Generic;
using Chapter02.Exercises.Exercise03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Exercise03
{
    [TestClass]
    public class SolutionTests
    {
        [DataTestMethod]
        [DynamicData(nameof(ExpectedBiggerSections))]
        public void Solve_Returns_NameOfBiggerSection(double mosaicSpace, IShape[] tiles, bool expectedIsCovered)
        {
            var isCovered = Solution.IsEnough(mosaicSpace, tiles);

            Assert.AreEqual(expectedIsCovered, isCovered);
        }

        public static IEnumerable<object[]> ExpectedBiggerSections
        {
            get
            {
                yield return new object[]
                {
                    0,
                    new IShape[0],
                    true
                };

                yield return new object[]
                {
                    0,
                    new []{new Circle(1)},
                    true
                };

                yield return new object[]
                {
                    1,
                    new []{new Circle(1)},
                    true
                };

                yield return new object[]
                {
                    6,
                    new []{new Circle(1)},
                    false
                };

                yield return new object[]
                {
                    2,
                    new []{new Rectangle(1,2)},
                    true
                };

                yield return new object[]
                {
                    20,
                    new IShape[]
                    {
                        new Rectangle(1,2),
                        new Circle(2)
                    },
                    false
                };

                yield return new object[]
                {
                    8,
                    new IShape[]
                    {
                        new Rectangle(1,2),
                        new Circle(2)
                    },
                    true
                };
            }
        }
    }
}
