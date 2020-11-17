using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Chapter02.Examples.CsharpKeywords.Generics.Comparator;

namespace Tests.Chapter02.Examples.Generics.ComparatorTests
{
    [TestClass]
    public class IsFirstBiggerTests
    {
        [DataTestMethod]
        [DynamicData(nameof(IsFirstBiggerExpectationsInt))]
        public void IsFirstBigger1_Returns_true_ifFirstBiggerInt(int first, int second, bool expectedIsFirstBigger)
        {
            IsFirstBigger1_Returns_true_ifFirstBigger(first, second, expectedIsFirstBigger);
        }

        [DataTestMethod]
        [DynamicData(nameof(IsFirstBiggerExpectationsDecimal))]
        public void IsFirstBigger1_Returns_true_ifFirstBiggerDecimal(decimal first, decimal second, bool expectedIsFirstBigger)
        {
            IsFirstBigger1_Returns_true_ifFirstBigger(first, second, expectedIsFirstBigger);
        }

        [DataTestMethod]
        [DynamicData(nameof(IsFirstBiggerExpectationsDummy))]
        public void IsFirstBigger1_Returns_true_ifFirstBiggerDummy(Dummy first, Dummy second, bool expectedIsFirstBigger)
        {
            IsFirstBigger1_Returns_true_ifFirstBigger(first, second, expectedIsFirstBigger);
        }

        [DataTestMethod]
        [DynamicData(nameof(IsFirstBiggerExpectationsInt))]
        public void IsFirstBigger2_Returns_true_ifFirstBiggerInt(int first, int second, bool expectedIsFirstBigger)
        {
            IsFirstBigger2_Returns_true_ifFirstBigger(first, second, expectedIsFirstBigger);
        }

        [DataTestMethod]
        [DynamicData(nameof(IsFirstBiggerExpectationsDecimal))]
        public void IsFirstBigger2_Returns_true_ifFirstBiggerDecimal(decimal first, decimal second, bool expectedIsFirstBigger)
        {
            IsFirstBigger2_Returns_true_ifFirstBigger(first, second, expectedIsFirstBigger);
        }

        [DataTestMethod]
        [DynamicData(nameof(IsFirstBiggerExpectationsDummy))]
        public void IsFirstBigger2_Returns_true_ifFirstBiggerDummy(Dummy first, Dummy second, bool expectedIsFirstBigger)
        {
            IsFirstBigger2_Returns_true_ifFirstBigger(first, second, expectedIsFirstBigger);
        }

        private static void IsFirstBigger2_Returns_true_ifFirstBigger<T>(T first, T second, bool expectedIsFirstBigger)
            where T: IComparable
        {
            var isFirstBigger = IsFirstBigger2(first, second);

            Assert.AreEqual(expectedIsFirstBigger, isFirstBigger);
        }

        private static void IsFirstBigger1_Returns_true_ifFirstBigger(IComparable first, IComparable second, bool expectedIsFirstBigger)
        {
            var isFirstBigger = IsFirstBigger1(first, second);

            Assert.AreEqual(expectedIsFirstBigger, isFirstBigger);
        }

        public static IEnumerable<object[]> IsFirstBiggerExpectationsInt
        {
            get
            {
                yield return new object[] {1, 2, false};
                yield return new object[] {2, 1, true};
                yield return new object[] {-1, 1, false};
                yield return new object[] {1, 1, false};
            }
        }

        public static IEnumerable<object[]> IsFirstBiggerExpectationsDecimal
        {
            get
            {
                yield return new object[] {1.1m, 2.1m, false};
                yield return new object[] {2.1m, 1.1m, true};
                yield return new object[] {-1.1m, 1.2m, false};
                yield return new object[] {1.1m, 1.1m, false};
            }
        }

        public static IEnumerable<object[]> IsFirstBiggerExpectationsDummy
        {
            get
            {
                yield return new object[] { new Dummy(), new Dummy(), false };
            }
        }
    }
}