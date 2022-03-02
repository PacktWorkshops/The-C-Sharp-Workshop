using System;
namespace Chapter03Examples
{
    class MulticastDelegatesAddRemoveExample
    {
        public static void Main()
        {
            Action<string> logger = LogToConsole;
            Console.WriteLine($"Logger1 #={logger.GetHashCode()}");

            logger += LogToConsole;
            Console.WriteLine($"Logger2 #={logger.GetHashCode()}");

            logger += LogToConsole;
            Console.WriteLine($"Logger3 #={logger.GetHashCode()}");

            Console.ReadLine();

            static void LogToConsole(string message)
                => Console.WriteLine($"{DateTime.Now}:{message}");
        }

    }
}
