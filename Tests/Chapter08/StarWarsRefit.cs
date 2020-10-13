using Chapter08.Interfaces;
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
            Assert.IsTrue(response.Data.Any());
        }

        [TestMethod]
        public void GetAllPlanets()
        {
            var results = GetApi().GetAllPlanetsAsync().Result;
            Assert.IsTrue(results.Count() > 10); // exact number could vary, just be sure it's more than a single page's worth
        }

        [TestMethod]
        public void GetOnePlanet()
        {
            var planet = GetApi().GetPlanetAsync(2).Result;
            Assert.IsTrue(planet.Name.Equals("Alderaan"));
        }

        private IStarWarsApi GetApi() => RestService.For<IStarWarsApi>("https://swapi.dev/api/");
    }
}
