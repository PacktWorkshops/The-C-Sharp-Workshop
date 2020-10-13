using System;
using System.Threading;
using System.Threading.Tasks;

namespace Examples.Chapter05
{
    class ContinuationExamples
    {

        public static void Main()
        {
            Logger.Log("Start...");
            Task
                .Run(GetStockPrice)
                .ContinueWith(prev =>
                {
                    Logger.Log($"GetPrice returned {prev.Result:N2}, status={prev.Status}");
                });

            Console.ReadLine();
        }

        private static double GetStockPrice()
        {
            Logger.Log("Inside GetStockPrice");
            Thread.Sleep(TimeSpan.FromSeconds(5D));
            return new Random().NextDouble() * 100D;
        }
    }
}
