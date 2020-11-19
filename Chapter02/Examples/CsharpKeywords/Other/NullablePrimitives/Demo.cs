using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02.Examples.CsharpKeywords.Other.NullablePrimitives
{
    public static class Demo
    {
        public static void Run()
        {
            int? a = null;
            a = 1;
            int b;
            if (a.HasValue)
            {
                b = a.Value;
            }
            else
            {
                b = 0;
            }

            Console.WriteLine($"a={a}, b={b}");
        }
    }
}
