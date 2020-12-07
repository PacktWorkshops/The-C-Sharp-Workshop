using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter10.Lib
{
    public class BankAccount
    {
        public BankAccount(double openingBalance)
            => OpeningBalance = openingBalance;

        public double OpeningBalance { get; init;}

        public List<double> Transactions { get; } = new List<double>();

        public double Balance()
            => OpeningBalance + Transactions.Sum();

    }

    public class BankTeller
    {
        public static void Transfer(BankAccount from, BankAccount to, double amount)
        {
            if (amount <= 0D )
                throw new ApplicationException("Cannot transfer negative amounts");

            if (from.Balance() < amount)
                throw new ApplicationException("Insufficent funds");

            from.Transactions.Add(amount * - 1D);
            to.Transactions.Add(amount);
        }

    }

}
