using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Chapter3;
using System.IO;

namespace Chapter3UnitTest
{

    [TestClass]
    public class Exercise03Tests
    {
        [TestMethod]
        public void DoWork_LogsToConsoleAndFile()
        {
            // ARRANGE
            using var writer = new StringWriter();
            Console.SetOut(writer);

            // ACT
            new CashMachineController().DoWork();
            writer.Flush();// Ensure writer is flushed

            // ASSERT
            const string ExpectedOutput = "[PIN: 1234][Balance: 999]";

            var actualConsole = writer.ToString();
            Assert.AreEqual(ExpectedOutput, actualConsole);

            var fileFile = File.ReadAllText("activity.txt");
            Assert.AreEqual(ExpectedOutput, fileFile);

            // older C# style
            //using (var writer = new StringWriter())
            //{
            //    Console.SetOut(writer);
            //    new MulticastController().DoWork();
            //    writer.Flush();
            //    var actualConsole = writer.ToString();
            //}
        }
    }
}

