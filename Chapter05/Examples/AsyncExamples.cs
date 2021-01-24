using System;
using System.Threading.Tasks;

namespace Chapter05.Examples
{
    class AsyncExamples
    {
        public static async Task Main()
        {
            global::Chapter05.Examples.Logger.Log("Starting");
            await BuildGreetings();

            global::Chapter05.Examples.Logger.Log("Press Enter");
            Console.ReadLine();
        }

        private static async Task BuildGreetings()
        {
            var message = "Morning";
            global::Chapter05.Examples.Logger.Log($"{message}");

            await Task.Delay(TimeSpan.FromSeconds(10D));

            message += "...Afternoon";
            global::Chapter05.Examples.Logger.Log($"{message}");

            await Task.Delay(TimeSpan.FromSeconds(1D));

            message += "...Evening";
            global::Chapter05.Examples.Logger.Log($"{message}");
        }
    }
}
