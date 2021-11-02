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
            const string expectedDocumentAnalysis = @"Document sentiment: Positive

Text: ""Today is a great day.""
Sentence sentiment: Positive
Positive score: 1,00
Negative score: 0,00
Neutral score: 0,00

Text: ""I had a wonderful dinner with my family!""
Sentence sentiment: Positive
Positive score: 1,00
Negative score: 0,00
Neutral score: 0,00

Opinions: 
dinner is wonderful";

            Demo.Run();

            Assert.AreEqual(expectedDocumentAnalysis, ConsoleOutput);
        }
    }
}
