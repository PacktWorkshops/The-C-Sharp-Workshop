using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter09
{
    [TestClass]
    public class EnvironmentalVariablesCheck
    {
        [DataRow("BlobStorageKey")]
        [DataRow("x-rapidapi-key")]
        [DataTestMethod]
        public void GetEnvironmentalVariable_ReturnsNotNull(string name)
        {
            var value = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User);

            Assert.IsNotNull(value);
        }
    }
}
