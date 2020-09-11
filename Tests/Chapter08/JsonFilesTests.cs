using Chapter08.Service.Static;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter08
{
    [TestClass]
    public class JsonFilesTests
    {
        [TestMethod]
        public void GetIdFromUrl()
        {
            var id = JsonFiles.IdFromUrl("http://swapi.dev/api/people/55/");
            Assert.IsTrue(id == 55);

            id = JsonFiles.IdFromUrl("http://swapi.dev/api/people/55");
            Assert.IsTrue(id == 55);
        }
    }
}
