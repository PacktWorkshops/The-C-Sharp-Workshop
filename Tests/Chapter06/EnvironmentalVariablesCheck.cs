using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter06
{
    [TestClass]
    public class EnvironmentalVariablesCheck
    {
        [DataRow("GlobalFactory")]
        [DataRow("AdventureWorks")]
        [DataRow("TruckLogistics")]
        [DataTestMethod]
        public void GetEnvironmentalVariable_ReturnsNotNull(string name)
        {
            var value = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User);

            Assert.IsNotNull(value);
        }
    }
}
