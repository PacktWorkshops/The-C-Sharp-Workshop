using System;

namespace Chapter3
{
    public class CashMachine
    {
        private readonly Action<string> _logger;

        public CashMachine(Action<string> logger)
        {
            _logger = logger;
        }

        private void Log(string message)
        {
            _logger?.Invoke(message);
        }

        public void VerifyPin()
        {
            Log("[PIN: 1234]");
        }

        public void ShowBalance()
        {
            Log("[Balance: 999]");
        }
    }
    public class CashMachineController
    {
        public void DoWork()
        {
            // Needs to be null rather than unassigned
            Action<string> logger = null;

            // use method group syntax to add target methods
            logger += LogToConsole;
            logger += LogToFile;

            var cashMachine = new CashMachine(logger);
            cashMachine.VerifyPin();
            cashMachine.ShowBalance();
        }

        private static void LogToConsole(string message)
            => System.Console.Write(message);

        private static void LogToFile(string message)
            => System.IO.File.AppendAllText("activity.txt", message);
    }


}