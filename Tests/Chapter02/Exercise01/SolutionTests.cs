using System;
using System.Collections.Generic;
using System.Text;
using Chapter02.Exercises.Exercise01;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Exercise01
{
    [TestClass]
    public class SolutionTests
    {
        [DataTestMethod]
        [DynamicData(nameof(ExpectedBiggerSections))]
        public void Solve_Returns_NameOfBiggerSection(Rectangle[] rectangularSection, Circle[] circularSection,
            string expectedBigger)
        {
            string bigger = Solution.Solve(rectangularSection, circularSection);

            Assert.AreEqual(expectedBigger, bigger);
        }

        public static IEnumerable<object[]> ExpectedBiggerSections
        {
            get
            {
                yield return new object[]
                {
                    new Rectangle[] { },
                    new Circle[] { },
                    Solution.Equal
                };

                yield return new object[]
                {
                    new[] {new Rectangle(1, 1)},
                    new Circle[] { },
                    Solution.Rectangular
                };

                yield return new object[]
                {
                    new Rectangle[] { },
                    new[] {new Circle(1),},
                    Solution.Circular
                };

                yield return new object[]
                {
                    new[] {new Rectangle(5, 10)},
                    new[] {new Circle(1)},
                    Solution.Rectangular
                };

                yield return new object[]
                {
                    new[] {new Rectangle(1, 1),},
                    new[] {new Circle(5)},
                    Solution.Circular
                };

                yield return new object[]
                {
                    new[]
                    {
                        new Rectangle(1, 1),
                        new Rectangle(1, 1),
                        new Rectangle(1, 2)
                    },
                    new[]
                    {
                        new Circle(10),
                    },
                    Solution.Circular
                };

                yield return new object[]
                {
                    new[]
                    {
                        new Rectangle(1, 1),
                        new Rectangle(1, 1)
                    },
                    new[]
                    {
                        new Circle(0.1),
                    },
                    Solution.Rectangular
                };

                yield return new object[]
                {
                    new[]
                    {
                        new Rectangle(1, 1),
                        new Rectangle(1, 1)
                    },
                    new[]
                    {
                        new Circle(1.5),
                        new Circle(1.1),
                        new Circle(1),
                    },
                    Solution.Circular
                };

                yield return new object[]
                {
                    new[]
                    {
                        new Rectangle(1, Math.PI),
                    },
                    new[]
                    {
                        new Circle(1)
                    },
                    Solution.Equal
                };

                yield return new object[]
                {
                    new[]
                    {
                        new Rectangle(0.25, Math.PI),
                        new Rectangle(0.75, Math.PI),
                    },
                    new[]
                    {
                        new Circle(1)
                    },
                    Solution.Equal
                };
            }


        }
    }
}
