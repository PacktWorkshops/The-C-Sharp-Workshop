using System;

namespace Chapter03Examples
{
    class FuncExample
    {
        public static void Main1()
        {
            Func<int, string> mathCalc = Func1;
            mathCalc += Func2;

            var resultA = mathCalc(2);
            Console.WriteLine($"ResultA={resultA}");

             var resultB = mathCalc(4);
            Console.WriteLine($"ResultB={resultB}");
        }

        private static string Func1(int num)
        {
            Console.WriteLine($"Called Func1({num})");
            return $"Func1: num = {num}";
        }

        private static string Func2(int num)
        {
            Console.WriteLine($"Called Func2({num})");
            return $"Func2: num = {num}";
        }
    }

}
