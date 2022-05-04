using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter05.Examples
{
    public class AsyncExamples
    {
        public static async Task Main()
        {
            Logger.Log("Starting");
            await BuildGreetings();

            Logger.Log("Press Enter");
            Console.ReadLine();
        }

        private static async Task BuildGreetings()
        {
            var message = "Morning";
            Logger.Log($"{message}");

            await Task.Delay(TimeSpan.FromSeconds(10D));

            message += "...Afternoon";
            Logger.Log($"{message}");

            await Task.Delay(TimeSpan.FromSeconds(1D));

            message += "...Evening";
            Logger.Log($"{message}");
        }
    }
}
