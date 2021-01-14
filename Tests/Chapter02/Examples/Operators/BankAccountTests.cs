using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter02.Examples.CsharpKeywords.Operators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Examples.Operators
{
    [TestClass]
    public class BankAccountTests
    {
        [DataTestMethod]
        [DynamicData(nameof(MoreExpectations))]
        public void More_Returns_True_WhenBalance1Bigger(decimal balance1, decimal balance2, bool expectedIsMore)
        {
            var account1 = new BankAccount(balance1);
            var account2 = new BankAccount(balance2);

            bool isMore = account1 > account2;

            Assert.AreEqual(isMore, expectedIsMore);
        }

        [DataTestMethod]
        [DynamicData(nameof(LessExpectations))]
        public void Less_Returns_True_WhenBalance2Bigger(decimal balance1, decimal balance2, bool expectedIsLess)
        {
            var account1 = new BankAccount(balance1);
            var account2 = new BankAccount(balance2);

            bool isMore = account1 < account2;

            Assert.AreEqual(isMore, expectedIsLess);
        }

        [DataTestMethod]
        [DynamicData(nameof(EqualExpectations))]
        public void Equal_Returns_True_WhenBalancesEqual(decimal balance1, decimal balance2, bool expectedIsEqual)
        {
            var account1 = new BankAccount(balance1);
            var account2 = new BankAccount(balance2);

            bool isMore = account1 == account2;

            Assert.AreEqual(isMore, expectedIsEqual);
        }

        [DataTestMethod]
        [DynamicData(nameof(NotEqualExpectations))]
        public void NotEqual_Returns_True_WhenBalancesNotEqual(decimal balance1, decimal balance2, bool expectedIsEqual)
        {
            var account1 = new BankAccount(balance1);
            var account2 = new BankAccount(balance2);

            bool isMore = account1 != account2;

            Assert.AreEqual(isMore, expectedIsEqual);
        }

        public static IEnumerable<object[]> MoreExpectations
        {
            get
            {
                yield return new object[] {1m, 1m, false};
                yield return new object[] {0m, 1m, false};
                yield return new object[] {1m, 0m, true};
                yield return new object[] {-2m, 1m, false};
            }
        }

        public static IEnumerable<object[]> LessExpectations
        {
            get
            {
                yield return new object[] {1m, 1m, false};
                yield return new object[] {0m, 1m, true};
                yield return new object[] {1m, 0m, false};
                yield return new object[] {-2m, 1m, true};
            }
        }

        public static IEnumerable<object[]> EqualExpectations
        {
            get
            {
                yield return new object[] { 1.1m, 1.1m, true };
                yield return new object[] { 0m, 1m, false };
                yield return new object[] { 1m, 0m, false };
                yield return new object[] { -1m, -1m, true };
                yield return new object[] { 1m, -1m, false };
            }
        }

        public static IEnumerable<object[]> NotEqualExpectations
        {
            get
            {
                yield return new object[] { 1.1m, 1.1m, false };
                yield return new object[] { 0m, 1m, true };
                yield return new object[] { 1m, 0m, true };
                yield return new object[] { -1m, -1m, false };
                yield return new object[] { 1m, -1m, true };
            }
        }
    }
}
