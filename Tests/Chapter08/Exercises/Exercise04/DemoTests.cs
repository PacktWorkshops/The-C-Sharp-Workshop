using System.IO;
using System.Threading.Tasks;
using Chapter08.Activities.Activity04;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;

namespace Tests.Chapter08.Exercises.Exercise04
{
    [TestClass]
    public class DemoTests : ConsoleTests
    {
        [TestMethod]
        public async Task Run_UploadsTest1Txt_And_UploadsMorningJpg_AndDownloadsBoth()
        {
            await Demo.Run();

            File.Exists($@"{Demo.Downloads}\Morning.jpg");
            File.Exists($@"{Demo.Downloads}\Test1.txt");
        }
    }
}
