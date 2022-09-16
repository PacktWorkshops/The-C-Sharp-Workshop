using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tests.Chapter03
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

            InvokeAll(logger, "Nothing to do");
            Assert.IsNull(consoleOutput);
            Assert.IsNull(debugOutput);

            logger += LogToConsole;
            logger += null; // add a null for fun
            logger += LogToError;
            logger += LogToDebug;

            const string Message = "this is a test";
            InvokeAll(logger, Message);
            
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

        private static void InvokeAll(Action<string> logger, string arg)
        {
            if (logger == null)
                return;

            var actions = logger.GetInvocationList().OfType<Action<string>>();
            foreach (var act in actions)
            {
                try
                {
                    Console.WriteLine($"Invoking '{act.Method.Name}'");
                    act(arg);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }
    }
}
