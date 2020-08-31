using System;
using Chapter3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chapter3UnitTest
{
    [TestClass]
    public class Exercise04Tests
    {
        [TestMethod]
        public void SafeInvoker_RunsAll()
        {
            string consoleOutput= null;
            string debugOutput = null;

            Action<string> logger = null;

            ActionHelpers.InvokeAll(logger, "Nothing to do");
            Assert.IsNull(consoleOutput);
            Assert.IsNull(debugOutput);

            logger += LogToConsole;
            logger += null; // add a null for fun
            logger += LogToError;
            logger += LogToDebug;

            const string Message = "this is a test";
            ActionHelpers.InvokeAll(logger, Message);
            
            // ASSERT
            Assert.AreEqual(Message, consoleOutput);
            Assert.AreEqual(Message, debugOutput);

            void LogToConsole(string message)
                => consoleOutput = message;

            void LogToError(string message)
                => throw new ApplicationException("bad thing happened!");

            void LogToDebug(string message)
                => debugOutput = $"{message}";
        }
    }
}
