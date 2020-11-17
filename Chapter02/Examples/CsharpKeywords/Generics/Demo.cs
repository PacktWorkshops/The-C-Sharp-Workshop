using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02.Examples.CsharpKeywords.Generics
{
    public static class Demo
    {
        public static void Run()
        {
            CollectionsPrinterv1.PrintG(1);
            CollectionsPrinterv1.PrintG(1f);
            CollectionsPrinterv1.PrintG(new object());
            CollectionsPrinterv1.PrintG("Hey");

            CollectionsPrinterv1.Print(new []{1,23,4,-1});

            int max1 = (int)Comparator.Max1(3, -4);
            int max2 = Comparator.Max2(3, -4);

            Console.WriteLine($"max1 = {max1} " +
                              $"max2 = {max2} ");

        }
    }
}
