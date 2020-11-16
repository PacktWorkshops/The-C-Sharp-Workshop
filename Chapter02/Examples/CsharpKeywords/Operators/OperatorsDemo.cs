using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02.Examples.CsharpKeywords.Operators
{
    public class OperatorsDemo
    {
        public static void Run()
        {
            var account1 = new BankAccount(-1.01m);
            var account2 = new BankAccount(1.01m);
            var account3 = new BankAccount(1001.99m);
            var account4 = new BankAccount(1001.99m);

            Console.WriteLine(account1 == account2);
            Console.WriteLine(account1 != account2);
            Console.WriteLine(account2 > account1);
            Console.WriteLine(account1 < account2);
            Console.WriteLine(account3 == account4);
            Console.WriteLine(account3 != account4);
        }
    }
}
