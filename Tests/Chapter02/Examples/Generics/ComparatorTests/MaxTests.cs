using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Chapter02.Examples.CsharpKeywords.Generics.Comparator;

namespace Tests.Chapter02.Examples.Generics.ComparatorTests
{
    [TestClass]
    public class MaxTests
    {
        [DataTestMethod]
        [DynamicData(nameof(IsFirstBiggerExpectationsInt))]
        public void Max1_Returns_BiggerOfTwoOrSecondInt(int first, int second, int expectedMax)
        {
            Max1_Returns_BiggerOfTwoOrSecond(first, second, expectedMax);
        }

        [DataTestMethod]
        [DynamicData(nameof(IsFirstBiggerExpectationsDecimal))]
        public void Max1_Returns_BiggerOfTwoOrSecondDecimal(decimal first, decimal second, decimal expectedMax)
        {
            Max1_Returns_BiggerOfTwoOrSecond(first, second, expectedMax);
        }

        [TestMethod]
        public void Max1_Returns_BiggerOfTwoOrSecondDummy()
        {
            Dummy d1 = new Dummy();
            Dummy d2 = new Dummy();
            Max1_Returns_BiggerOfTwoOrSecond(d1, d2, d2);
        }

        [DataTestMethod]
        [DynamicData(nameof(IsFirstBiggerExpectationsInt))]
        public void Max2_Returns_BiggerOfTwoOrSecondInt(int first, int second, int expectedMax)
        {
            Max2_Returns_BiggerOfTwoOrSecond(first, second, expectedMax);
        }

        [DataTestMethod]
        [DynamicData(nameof(IsFirstBiggerExpectationsDecimal))]
        public void Max2_Returns_BiggerOfTwoOrSecondDecimal(decimal first, decimal second, decimal expectedMax)
        {
            Max2_Returns_BiggerOfTwoOrSecond(first, second, expectedMax);
        }

        [TestMethod]
        public void Max2_Returns_BiggerOfTwoOrSecondDummy()
        {
            Dummy d1 = new Dummy();
            Dummy d2 = new Dummy();
            Max2_Returns_BiggerOfTwoOrSecond(d1, d2, d2);
        }

        private static void Max1_Returns_BiggerOfTwoOrSecond(IComparable first, IComparable second, IComparable expectedMax)
        {
            var max = Max2(first, second);

            Assert.AreEqual(expectedMax, max);
        }

        private static void Max2_Returns_BiggerOfTwoOrSecond<T>(T first, T second, T expectedMax)
            where T : IComparable
        {
            var max = Max2(first, second);

            Assert.AreEqual(expectedMax, max);
        }

        public static IEnumerable<object[]> IsFirstBiggerExpectationsInt
        {
            get
            {
                yield return new object[] { 1, 2, 2 };
                yield return new object[] { 2, 1, 2 };
                yield return new object[] { -2, 1, 1 };
                yield return new object[] { 1, 1, 1 };
            }
        }

        public static IEnumerable<object[]> IsFirstBiggerExpectationsDecimal
        {
            get
            {
                yield return new object[] { 1.1m, 2.1m, 2.1m };
                yield return new object[] { 2.1m, 1.1m, 2.1m, };
                yield return new object[] { -1.3m, 1.2m, 1.2m };
                yield return new object[] { 1.1m, 1.1m, 1.1m };
            }
        }
    }
}