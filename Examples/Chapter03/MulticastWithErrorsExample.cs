using System;
using System.Diagnostics;

namespace Chapter03Examples
{
    class MulticastWithErrorsExample

    {
            public static void Main()
            {
                Action<string> logger = LogToConsole;
                logger += LogToError;
                logger += LogToDebug;

                try
                {
                    logger("try log this");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Caught {e.Message}");
                }
                Console.WriteLine("All done");

                static void LogToConsole(string message)
                    => Console.WriteLine($"Console: {message}");

                static void LogToError(string message)
                    => throw new ApplicationException("oops!");

                static void LogToDebug(string message)
                    => Debug.WriteLine($"Debug: {message}");

        }

    }
}
