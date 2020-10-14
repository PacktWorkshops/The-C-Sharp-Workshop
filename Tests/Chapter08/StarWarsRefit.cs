using Chapter08.Interfaces;
using Chapter08.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refit;
using System;
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
        public void GetAllPlanetsOld()
        {
            var results = GetApi().GetAllPlanetsAsyncOld().Result;
            Assert.IsTrue(results.Count() > 10); // exact number could vary, just be sure it's more than a single page's worth
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

        [TestMethod]
        public void GetPlanetsWhere()
        {
            Func<Planet, bool> predicate = (p) => p.Name.ToLower().StartsWith("a");
            var results = GetApi().GetAllPlanetsAsync(predicate).Result;
            Assert.IsTrue(results.All(predicate));
        }

        [TestMethod]
        public void GetPlanetsOrderBy()
        {
            Func<Planet, object> orderBy = (p) => p.Name;
            var results = (GetApi().GetAllPlanetsAsync(orderBy: orderBy).Result).Take(3);
            Assert.IsTrue(results.Select(p => p.Name).SequenceEqual(new string[] { "Alderaan", "Aleen Minor", "Bespin" }));
        }

        [TestMethod]
        public void GetPeople()
        {
            var results = GetApi().GetPeopleAsync().Result;
            Assert.IsTrue(results.Data.Count == 10);

            var allResults = GetApi().GetAllPeopleAsync().Result;
            Assert.IsTrue(allResults.Count() == results.Count);
        }

        [TestMethod]
        public void GetPerson()
        {
            var person = GetApi().GetPersonAsync(4).Result;
            Assert.IsTrue(person.Name.Equals("Darth Vader"));
        }

        [TestMethod]
        public void GetFilms()
        {
            var results = GetApi().GetFilmsAsync().Result;
            Assert.IsTrue(results.Data.Any());

            var allResults = GetApi().GetAllFilmsAsync().Result;
            Assert.IsTrue(allResults.Count() == results.Count);
        }

        [TestMethod]
        public void GetFilm()
        {
            var film = GetApi().GetFilmAsync(2).Result;
            Assert.IsTrue(film.Title.Equals("The Empire Strikes Back"));
        }

        private IStarWarsApi GetApi() => RestService.For<IStarWarsApi>("https://swapi.dev/api/");
    }
}
