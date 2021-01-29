using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chapter05.Examples
{

    class AsyncEnumerableExamplesProgram
    {
        public static async Task Main()
        {
            Logger.Log("Fetching Task quotes...");
            var taskQuotes = await GetInsuranceQuotesAsTask();
            foreach(var quote in taskQuotes)
            {
                Logger.Log($"Received Task: {quote}");
            }

            Logger.Log("Fetching Stream quotes...");
            await foreach (var quote in GetInsuranceQuotesAsync())
            {
                Logger.Log($"Received Stream: {quote}");
            }

            Logger.Log("All done...");

            Console.ReadLine();
        }

        private static async Task<IEnumerable<string>> GetInsuranceQuotesAsTask()
        {
            var rand = new Random();
            var quotes = new List<string>();

            for (var i = 0; i < 5; i++)
            {
                await Task.Delay(1500);
                quotes.Add($"Provider{i}'s quote is {rand.Next(5, 10)}");
            }

            return quotes;
        }

        private static async IAsyncEnumerable<string> GetInsuranceQuotesAsync()
        {
            var rand = new Random();

            for (var i = 0; i < 5; i++)
            {
                await Task.Delay(1500);
                yield return $"Provider{i}'s quote is {rand.Next(5, 10)}";
            }

        }

    }


}
