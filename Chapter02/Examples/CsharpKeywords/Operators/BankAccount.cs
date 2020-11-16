using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02.Examples.CsharpKeywords.Operators
{
    public class BankAccount
    {
        private decimal _balance;

        public BankAccount(decimal balance)
        {
            _balance = balance;
        }

        public static bool operator >(BankAccount account1, BankAccount account2)
            => account1?._balance > account2?._balance;

        public static bool operator <(BankAccount account1, BankAccount account2)
            => account1?._balance < account2?._balance;

        public static bool operator ==(BankAccount account1, BankAccount account2)
            => account1?._balance == account2?._balance;

        public static bool operator !=(BankAccount account1, BankAccount account2)
            => !(account1 == account2);

        public static bool operator *(BankAccount account1, BankAccount account2)
        {
            return false;
        }
    }
}
