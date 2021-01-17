using NUnit.Framework;
using Chapter10.Lib;
using System;
using System.Linq;

namespace Chapter10.Tests
{
    [TestFixture]
    public class BankTellerTests
    {
        [Test]
        public void Transfer_ValidBalance_AddsToTransactions()
        {
            // ARRANGE
            Random random = new();

            var fromOpeningBalance = random.NextDouble() * 1000D;
            var fromAccount = new BankAccount(fromOpeningBalance);

            var toOpeningBalance = random.NextDouble() * 500D;
            var toAccount = new BankAccount(toOpeningBalance);

            var transferAmount = random.NextDouble() * 10D;

            // ACT
            BankTeller.Transfer(fromAccount, toAccount, transferAmount);

            // ASSERT
            Assert.That(fromAccount.Transactions.Count, Is.EqualTo(1));
            Assert.That(fromAccount.Transactions.Contains(transferAmount *-1D));   
            Assert.That(fromAccount.Balance, Is.EqualTo(fromOpeningBalance - transferAmount));

            Assert.That(toAccount.Transactions.Count, Is.EqualTo(1));
            Assert.That(toAccount.Transactions.Contains(transferAmount));    
            Assert.That(toAccount.Balance, Is.EqualTo(toOpeningBalance + transferAmount));
        }

        [Test]
        public void Transfer_NegativeAmount_ThrowsException()
        {
            Assert.Throws<ApplicationException>( () => 
            {
                var from = new BankAccount(1);
                var to = new BankAccount(2);

                BankTeller.Transfer(from, to, -1D);

                Assert.That(from.Transactions.Any(), Is.False);
                Assert.That(to.Transactions.Any(), Is.False);
            });
        }

        [Test]
        public void Transfer_BalanceTooLow_ThrowsException()
        {
            Assert.Throws<ApplicationException>( () => 
            {
                var from = new BankAccount(1);
                var to = new BankAccount(2);

                BankTeller.Transfer(from, to, from.Balance() + 1D);

                Assert.That(from.Transactions.Any(), Is.False);
                Assert.That(to.Transactions.Any(), Is.False);
            });
        }
    }
}