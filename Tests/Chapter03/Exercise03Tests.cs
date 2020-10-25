using System;
using System.IO;
using Chapter03.Exercise03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter03
{

    [TestClass]
    public class Exercise03Tests
    {
        private const string OutputFile = "activity.txt";

        [TestInitialize]
        public void Setup()
        {
            if (File.Exists(OutputFile))
            {
                File.Delete(OutputFile);
            }
        }

        [TestMethod]
        public void LogsToConsoleAndFile()
        {
            // ARRANGE
            using var writer = new StringWriter();
            Console.SetOut(writer);

            Action<string> logger = LogToConsole;
            logger += LogToFile;

            var cashMachine = new CashMachine(logger);

            const string Pin = "1234";
            cashMachine.VerifyPin(Pin);
            cashMachine.ShowBalance();
            
            writer.Flush();// Ensure writer is flushed

            // ASSERT
            var expectedOutput = $"VerifyPin called: PIN={Pin}ShowBalance called: Balance=999";

            var actualConsole = writer.ToString();
            Assert.AreEqual(expectedOutput, actualConsole);

            var fileText = File.ReadAllText(OutputFile);
            Assert.AreEqual(expectedOutput, fileText);
        }

        private static void LogToConsole(string message)
            => Console.Write(message);

        private static void LogToFile(string message)
            => System.IO.File.AppendAllText("activity.txt", message);
    }
}

