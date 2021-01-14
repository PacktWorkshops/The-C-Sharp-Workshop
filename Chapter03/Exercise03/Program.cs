using System;
using System.IO;

namespace Chapter03.Exercise03
{
    public class CashMachine
    {
        private readonly Action<string> _logger;

        public CashMachine(Action<string> logger)
        {
            _logger = logger;
        }

        private void Log(string message) 
            => _logger?.Invoke(message);

        public void VerifyPin(string pin) 
            => Log($"VerifyPin called: PIN={pin}");

        public void ShowBalance() 
            => Log("ShowBalance called: Balance=999");
    }

    public static class Program
    {
        private const string OutputFile = "activity.txt";

        public static void Main()
        {
            if (File.Exists(OutputFile))
            {
                File.Delete(OutputFile);
            }

            Action<string> logger = LogToConsole;
            logger += LogToFile;

            var cashMachine = new CashMachine(logger);

            Console.Write("Enter your PIN:");
            var pin = Console.ReadLine();

            cashMachine.VerifyPin(pin);
            Console.WriteLine();

            Console.Write("Press Enter to show balance");
            Console.ReadLine();

            cashMachine.ShowBalance();

            Console.Write("Press Enter to quit");
            Console.ReadLine();

            static void LogToConsole(string message)
                => Console.WriteLine(message);

            static void LogToFile(string message)
                => File.AppendAllText(OutputFile, message);
        }
        
    }
}