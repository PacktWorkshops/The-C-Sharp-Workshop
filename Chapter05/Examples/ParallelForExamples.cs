using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter05.Examples
{
    class ParallelForExamples
    {

        public static async Task Main()
        {
            var loopResult = Parallel.For(99, 105, i =>
            {
                Logger.Log($"Sleep iteration {i}");
                Thread.Sleep(i * 10);
                Logger.Log($"Awake iteration {i}");
            });
            
            Console.WriteLine($"Completed: {loopResult.IsCompleted}");
            Console.ReadLine();

            var loopResult1 = Parallel.For(10, 20, (i, loopState) =>
            {
                Logger.Log($"Inside iteration {i}");
                if (i == 15)
                {
                    Logger.Log($"At {i}...break when you're ready");
                    loopState.Break();
                }
            });
            Console.WriteLine($"Completed: {loopResult1.IsCompleted}, LowestBreakIteration={loopResult1.LowestBreakIteration}");
            Console.ReadLine();

            var loopResult2 = Parallel.For(100, 150, (i, loopState) =>
            {
                Logger.Log($"Inside iteration {i}. Stopped={loopState.IsStopped}");
                if (i == 105)
                {
                    Logger.Log($"At {i}..STOP!");
                    loopState.Stop();
                }

                if (!loopState.IsStopped)
                {
                    Thread.Sleep(1000);
                    Logger.Log($"Awake iteration {i}");
                }
            });
            Console.WriteLine($"Completed: {loopResult2.IsCompleted}, LowestBreakIteration={loopResult2.LowestBreakIteration}");
            Console.ReadLine();

            double series;
            do
            {
                Console.Write("Pi Series (in millions):");
                var input = Console.ReadLine();
                if (!double.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out series))
                {
                    break;
                }

                var actualSeries = series * 1000000;
                Console.WriteLine($"Calculating PI {actualSeries:N0}");
                var pi = await CalcPi((int)(actualSeries));
                Console.WriteLine($"PI={pi:N18}");

            }
            while (series != 0D);
            Console.ReadLine();

        }

        private static Task<double> CalcPi(int steps)
        {
            return Task.Run(() =>
            {
                const int StartIndex = 0;

                var sum = 0.0D;
                var step = 1.0D / (double)steps;
                var gate = new object();

                Parallel.For(
                    StartIndex, 
                    steps,

                    () => 0.0D,                 // localInit 

                    (i, state, localFinal) =>   // body
                    {
                        var x = (i + 0.5D) * step;
                        return localFinal + 4.0D / (1.0D + x * x);
                    },

                    localFinal =>               //localFinally
                    { 
                        lock (gate)
                            sum += localFinal; 
                    });

                return step * sum;
            });

        }
    }
}
