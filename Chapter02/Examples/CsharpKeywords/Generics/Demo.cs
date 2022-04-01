using System;
using System.Collections.Generic;

namespace Chapter02.Examples.CsharpKeywords.Generics
{
    public static class Demo
    {
        public static void Run()
        {
            CollectionsPrinterv1.Print(1);
            CollectionsPrinterv1.Print(1f);
            CollectionsPrinterv1.Print(new object());
            CollectionsPrinterv1.Print("Hey");

            CollectionsPrinterv1.Print(new[] { 1, 23, 4, -1 });

            int max1 = (int)Comparator.Max1(3, -4);
            int max2 = Comparator.Max2(3, -4);

            Console.WriteLine($"max1 = {max1} " +
                              $"max2 = {max2} ");
        }
    }
}
