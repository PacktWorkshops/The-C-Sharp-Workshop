using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter08
{
    [TestClass]
    public class EnvironmentalVariablesCheck
    {
        [DataRow("GitHubPersonalAccess")]
        [DataRow("GithubClientId")]
        [DataRow("GithubSecret")]
        [DataRow("TextAnalysisApiKey")]
        [DataRow("TextAnalysisEndpoint")]
        [DataRow("PayPalClientId")]
        [DataRow("PayPalSecret")]
        [DataRow("BlobStorageKey")]
        [DataTestMethod]
        public void GetEnvironmentalVariable_ReturnsNotNull(string name)
        {
            var value = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User);

            Assert.IsNotNull(value);
        }
    }
}
