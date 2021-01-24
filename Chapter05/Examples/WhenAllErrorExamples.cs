using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter05.Examples
{
    class WhenAllErrorExamples
    {
        private static async Task<int> BadTask(string info, int n)
        {
            await Task.Delay(1000);

            Logger.Log($"{info} number {n} awake");

            if (n % 2 == 0)
            {
                Logger.Log($"About to throw one {info} number {n}...");
                throw new InvalidOperationException($"Oh dear from {info} number {n}");
            }

            return n;
        }

        private static IEnumerable<Task<int>> CreateBadTasks(string info)
        {
            return Enumerable.Range(0, 5)
                .Select(i => BadTask(info, i))
                .ToList();
        }

        public static async Task Main()
        {
            var whenAllCompletedTask = Task.WhenAll(CreateBadTasks("[WhenAll]"));
            try
            {
                await whenAllCompletedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"WhenAll Caught {ex.GetType().Name}, Message={ex.Message}");
                Console.WriteLine($"WhenAll Task.Status={whenAllCompletedTask.Status}");
                foreach (var ie in whenAllCompletedTask.Exception.InnerExceptions)
                {
                    Console.WriteLine($"WhenAll Caught Inner Exception: {ie.Message}");
                }
            }

            var whenAnyCompletedTask = Task.WhenAny(CreateBadTasks("[WhenAny]"));
            var result = await whenAnyCompletedTask;
            Logger.Log($"WhenAny result: {result.Result}");

            Console.ReadLine();
        }

        
    }
}
