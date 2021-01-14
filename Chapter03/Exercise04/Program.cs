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

            Console.ReadLine();
            
            static void LogToConsole(string message)
                => Console.WriteLine($"LogToConsole: {message}");

            static void LogToDatabase(string message)
                => throw new ApplicationException("bad thing happened!");

            static void LogToFile(string message)
                => File.AppendAllText(OutputFile, message);

            static void InvokeAll(Action<string> logger, string arg)
            {
                if (logger == null)
                    return;

                var delegateList = logger.GetInvocationList();
                Console.WriteLine($"Found {delegateList.Length} items in {logger}");
                foreach (var del in delegateList)
                {
                    try
                    {
                        if (del is Action<string> action)
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

}