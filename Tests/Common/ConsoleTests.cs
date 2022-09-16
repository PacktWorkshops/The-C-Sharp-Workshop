using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Common
{
    public class ConsoleTests
    {
        /// <summary>
        /// Disposes console output file and returns its' contents.
        /// </summary>
        protected string ConsoleOutput
        {
            get
            {
                if (_consoleOutput == null)
                {
                    throw new ArgumentNullException(nameof(_consoleOutput));
                }

                _consoleOutput.Dispose();
                var content = FakeConsole.ReadAllText(_testKey).Trim();

                return content;
            }
        }

        /// <summary>
        /// Stubs <see cref="Console.ReadLine()"/> with the value set.
        /// </summary>
        protected string ConsoleInput
        {
            set
            {
                var input = new StringReader(value);
                Console.SetIn(input);
            }
        }

        /// <summary>
        /// Used for identifying test file for the current test case console redirected output.
        /// </summary>
        private string _testKey;
        private StreamWriter _consoleOutput;

        [TestInitialize]
        public void Setup()
        {
            RedirectConsoleToFile();
        }

        /// <summary>
        /// Fakes <see cref="Console.WriteLine()"/>.
        /// Console output goes to file.
        /// </summary>
        private void RedirectConsoleToFile()
        {
            _testKey = Guid.NewGuid().ToString();
            _consoleOutput = new StreamWriter($"{_testKey}.{FakeConsole.TestFileExtension}");
            Console.SetOut(_consoleOutput);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (_testKey != null)
            {
                _consoleOutput.Dispose();
                FakeConsole.Cleanup(_testKey);
            }
        }
    }
}