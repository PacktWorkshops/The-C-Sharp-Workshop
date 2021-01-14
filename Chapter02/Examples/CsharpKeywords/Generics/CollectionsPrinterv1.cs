using System;

namespace Chapter02.Examples.CsharpKeywords.Generics
{
    public static class CollectionsPrinterv1
    {
        public static void Print<T>(T[] elements)
        {
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }

        public static void Print(int element)
        {
            Console.WriteLine(element);
        }

        public static void Print(float element)
        {
            Console.WriteLine(element);
        }

        public static void Print(string element)
        {
            Console.WriteLine(element);
        }

        public static void Print(object element)
        {
            Console.WriteLine(element);
        }

        public static void PrintG<T>(T element)
        {
            Print(element);
        }
    }
}
