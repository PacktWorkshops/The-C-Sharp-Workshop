using System;

namespace Chapter02.Examples.CsharpKeywords.ExtensionMethods
{
    public static class StringExtensions
    {
        public static void Print(this string text)
        {
            Console.WriteLine(text);
        }
    }
}
