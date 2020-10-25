using System;
using System.IO;

namespace Chapter03.Exercise04
{
    public static class Program
    {
        private const string OutputFile = "Exercise04.txt";

        public static void Main()
        {
            if (File.Exists(OutputFile))
            {
                File.Delete(OutputFile);
            }

            Action<string> logger = LogToConsole;

            InvokeAll(logger, "First call");

            logger += LogToConsole;
            logger += LogToDatabase;
            logger += LogToFile;

            InvokeAll(logger, "Second call");

            static void LogToConsole(string message)
                => Console.WriteLine($"LogToConsole: {message}");

            static void LogToDatabase(string message)
                => throw new ApplicationException("bad thing happened!");

            static void LogToFile(string message)
                => File.AppendAllText(OutputFile, message);
        }

        private static void InvokeAll(Action<string> logger, string arg)
        {
            if (logger == null)
                return;

            // Can do this with linq but that's for next chapter
            //var actions = logger.GetInvocationList().OfType<Action<string>>();
            var delegateList = logger.GetInvocationList();
            Console.WriteLine($"Found {delegateList.Length} items in {logger}");
            foreach (var del in delegateList)
            {
                try
                {
                    var action = del as Action<string>;
                    if (action != null)
                    {
                        Console.WriteLine($"Invoking '{action.Method.Name}' with '{arg}'");
                        action(arg);
                    }
                    else
                    {
                        Console.WriteLine("Skipped null");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }
        
    }
   
}