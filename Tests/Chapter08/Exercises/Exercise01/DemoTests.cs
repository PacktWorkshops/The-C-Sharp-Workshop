using System.Threading.Tasks;
using Chapter08.Exercises.Exercise01;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;

namespace Tests.Chapter08.Exercises.Exercise01
{
    [TestClass]
    public class DemoTests : ConsoleTests
    {
        [TestMethod]
        public void Run_Prints_ExpectedDocumentSentimentalAnalysis()
        {
            const string expectedDocumentAnalysis = @"";

            Demo.Run();

            Assert.AreEqual(expectedDocumentAnalysis, ConsoleOutput);
        }
    }
}
