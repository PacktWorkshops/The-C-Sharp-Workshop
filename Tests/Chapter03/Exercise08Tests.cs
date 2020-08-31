using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chapter3;

namespace Chapter3UnitTest
{

    [TestClass]
    public class Exercise08Tests
    {
        [TestMethod]
        [DataRow("how are you", "you are how")]
        [DataRow(" this    is    visual studio ", "studio visual is this")]
        [DataRow(" one ", "one")]
        public void ReverseWords(string input, string expectedPhrase)
        {
            var actualPhrase = WordUtilities.ReverseWords(input);
            Assert.AreEqual(expectedPhrase, actualPhrase);
        }
    }
}
