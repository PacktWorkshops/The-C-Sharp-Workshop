using Chapter08.Client.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refit;
using System.Linq;

namespace Tests.Chapter08
{
    [TestClass]
    public class StarWarsRefit
    {
        [TestMethod]
        public void GetPlanets()
        {
            var response = GetApi().GetPlanetsAsync().Result;
            Assert.IsTrue(response.results.Any());
        }

        private IStarWarsApi GetApi() => RestService.For<IStarWarsApi>("https://swapi.dev/api/");

    }
}
