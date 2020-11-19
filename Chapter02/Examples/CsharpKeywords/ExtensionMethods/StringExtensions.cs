using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
