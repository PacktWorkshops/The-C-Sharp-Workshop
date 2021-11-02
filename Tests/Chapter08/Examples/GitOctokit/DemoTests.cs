using System.Threading.Tasks;
using Chapter08.Examples.GitOctokit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;

namespace Tests.Chapter08.Examples.GitOctokit
{
    [TestClass]
    public class DemoTests : ConsoleTests
    {
        [TestMethod]
        public async Task Run_Returns_AlmatasKWithCreatedAtProfileDate()
        {
            const string expectedUser = "Almantask created profile at 2018-06-22 07:51:56 +00:00";

            await Demo.Run();

            Assert.AreEqual(expectedUser, ConsoleOutput);
        }
    }
}
