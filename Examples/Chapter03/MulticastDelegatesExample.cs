using System;
namespace Chapter03Examples
{
    class MulticastDelegatesExample
    {
        public static void Main()
        {
            Action<string> logger = LogToConsole;
            logger += LogToConsole;
            logger("Console x 2");
             
            logger -= LogToConsole;
            logger("Console x 1");

            logger -= LogToConsole;
            logger("logger is now null");

            // C#8 local function
            static void LogToConsole(string message)
                => Console.WriteLine($"{DateTime.Now}:{message}");
        }

        // No c#8 ?
        //private static void LogToConsole(string message) 
        //    => Console.WriteLine($"{DateTime.Now}:{message}");

    }
}
