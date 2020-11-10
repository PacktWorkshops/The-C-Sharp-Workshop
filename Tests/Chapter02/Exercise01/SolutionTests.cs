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
        [DynamicData(nameof(ExpectedBiggerSections), DynamicDataSourceType.Property)]
        public void Solve_Returns_NameOfBiggerSection(Rectangle[] rectangularSection, Circle[] circularSection, string expectedBigger)
        {
            string bigger = Solution.Solve(rectangularSection, circularSection);

            Assert.AreEqual(bigger, expectedBigger);
        }

        public static IEnumerable<object[]> ExpectedBiggerSections
        {
            get 
            {
                // Both empty
                yield return new object[]
                {
                    new Rectangle[] { },
                    new Circle[] { },
                    Solution.Equal
                };

                // 1 rectangle, no circles
                yield return new object[]
                {
                    new[] { new Rectangle(1,1) },
                    new Circle[] { }, 
                    Solution.Rectangular
                };

                // no rectangles, 1 circle
                yield return new object[]
                {
                    new Rectangle[] { },
                    new[] { new Circle(1), },
                    Solution.Circular
                };

                // 1 of each, rectangle bigger
                yield return new object[]
                {
                    new [] { new Rectangle(5, 10) }, 
                    new[] { new Circle(1) },
                    Solution.Rectangular
                };

                // 1 of each, circle bigger
                yield return new object[]
                {
                    new [] { new Rectangle(1, 1), }, 
                    new[] { new Circle(5) }, 
                    Solution.Circular
                };

                // 3 small rectangles, circle bigger
                yield return new object[]
                {
                    new []
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

                // 2 small rectangles, even smaller circle
                yield return new object[]
                {
                    new []
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

                // 2 rectangles, 3 circles slightly bigger
                yield return new object[]
                {
                    new []
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

                // 1 rectangle, 1 circle equal
                yield return new object[]
                {
                    new []
                    {
                        new Rectangle(1, Math.PI),
                    },
                    new[]
                    {
                        new Circle(1)
                    },
                    Solution.Equal
                };

                // 2 rectangles, 1 circle equal
                yield return new object[]
                {
                    new []
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
