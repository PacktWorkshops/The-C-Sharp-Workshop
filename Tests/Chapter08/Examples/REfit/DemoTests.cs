using System.Threading.Tasks;
using Chapter08.Examples.REfit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;

namespace Tests.Chapter08.Examples.REfit
{
    [TestClass]
    public class DemoTests : ConsoleTests
    {
        [TestMethod]
        public async Task Run_PrintsStarWarsMovies_With_ReleaseDatesAndTitle()
        {
            const string expectedMovies = @"1977-05-25 A New Hope
1980-05-17 The Empire Strikes Back
1983-05-25 Return of the Jedi
1999-05-19 The Phantom Menace
2002-05-16 Attack of the Clones
2005-05-19 Revenge of the Sith";

            await Demo.Run();

            Assert.AreEqual(expectedMovies, ConsoleOutput);
        }
    }
}
