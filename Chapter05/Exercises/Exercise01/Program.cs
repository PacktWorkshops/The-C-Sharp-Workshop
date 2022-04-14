using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter05.Exercises.Exercise01
{
    class Program
    {

        private static long Fibonacci(int n)
        {
            if (n <= 2L)
                return 1L;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public static void Main()
        {
            string input;
            do
            {
                Console.WriteLine("Enter number:");
                input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input) &&
                    int.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out var number))
                {
                    Task.Run(() =>
                    {
                        var now = DateTime.Now;
                        var fib = Fibonacci(number);
                        var duration = DateTime.Now.Subtract(now);
                        Logger.Log($"Fibonacci {number:N0} = {fib:N0} (elapsed time: {duration.TotalSeconds:N0} secs)");
                    });
                }

            } while (input != string.Empty);
        }
    }
}
