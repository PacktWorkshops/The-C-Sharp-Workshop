using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Chapter05.Exercise01
{
    class Exercise01
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

                if (string.IsNullOrEmpty(input)) 
                    continue;

                //if (!int.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out number))
                if (int.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out var number))
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
