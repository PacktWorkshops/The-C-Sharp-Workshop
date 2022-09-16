using System.Threading.Tasks;
using Chapter08.Activities.Activity02;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;

namespace Tests.Chapter08.Activities.Activity02
{
    [TestClass]
    public class DemoTests : ConsoleTests
    {
        [TestMethod]
        public async Task Run_Prints_2Countries_With_NameAndCapital_ThenLithuaniaNameAndCapital_ThenVilniusNameAndCapital()
        {
            const string expectedCities = @"All:
Fiji Oceania Suva
Papua New Guinea Oceania Port Moresby

Lithuanian:
Lithuania Europe Vilnius

Vilnius:
Lithuania Europe Vilnius";

            await Demo.Run();

            Assert.AreEqual(expectedCities, ConsoleOutput);
        }
    }
}
