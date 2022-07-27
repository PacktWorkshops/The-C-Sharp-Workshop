using System;
using System.Threading.Tasks;
using Chapter08.Examples.GitHttp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;

namespace Tests.Chapter08.Examples.GitHttp
{
    [TestClass]
    public class DemoTests : ConsoleTests
    {
        [TestMethod]
        public async Task GetUser_Returns_AlmatasKWithCreatedAtProfileDate()
        {
            const string expectedUser = "Kaisinel created profile at 2018-06-22 07:51:56";

            await GitExamples.GetUser();

            Assert.AreEqual(expectedUser, ConsoleOutput);
        }

        [TestMethod]
        public async Task GetUser61Times_DoesNotThrow()
        {
            var token = GitExamples.GetBasicToken();

            Func<Task> getUser61Times = async () => await GitExamples.GetUser61Times(token);

            await getUser61Times.DoesNotThrow();
        }

        [TestMethod]
        public void GetToken_ReturnsBase64EncodedString()
        {
            var basicToken = GitExamples.GetBasicToken();

            var token = basicToken.Replace("Basic ", "", StringComparison.InvariantCultureIgnoreCase);
            Action tokenFromBase64String = () => Convert.FromBase64String(token);
            tokenFromBase64String.DoesNotThrow();
        }

        [TestMethod]
        [Ignore("To be run only if you change GitHttpExamples line 86")]
        public async Task UpdateEmploymentStatus_SetsIsHireableToTrue()
        {
            const string expectedProfileInfo = "";
            var token = await GitExamples.GetToken();

            await GitExamples.UpdateEmploymentStatus(true, token);

            Assert.IsTrue(ConsoleOutput.Contains("\"hireable\":true"), "Expected hireable to be set to true");
        }
    }
}
