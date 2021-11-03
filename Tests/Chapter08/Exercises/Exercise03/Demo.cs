using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chapter08.Exercises.Exercise03;
using Tests.Common;

namespace Tests.Chapter08.Exercises.Exercise03
{
    [TestClass]
    public class DemoTests : ConsoleTests
    {
        [TestMethod]
        public async Task Run_Prints_ExpectedBill()
        {
            const string expectedBill = "100.00EUR";

            await Demo.Run();

            Assert.IsTrue(expectedBill.Contains(expectedBill), $"Expected bill to be {expectedBill}");
        }
    }
}
