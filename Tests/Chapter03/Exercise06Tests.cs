using Chapter03.Exercise06;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter03
{
    [TestClass]
    public class Exercise06Tests
    {
        [TestMethod]
        [DataRow("how are you", "you are how")]
        [DataRow("this is visual studio", "studio visual is this")]
        public void ReverseWords(string input, string expectedPhrase)
        {
            var actualPhrase = WordUtilities.ReverseWords(input);
            Assert.AreEqual(expectedPhrase, actualPhrase);
        }
    }
}
