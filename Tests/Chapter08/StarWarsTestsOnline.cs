using Chapter08;
using Chapter08.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Bson;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Tests.Chapter08
{
    [TestClass]
    public class StarWarsTestsOnline
    {     
        [TestMethod]
        public void GetAllPeople()
        {
            var people = new StarWarsApiClient(HostOptions.Online).GetAllPeopleAsync().Result;
            Assert.IsTrue(people.Any());

            // make sure everyone is in at least one film (ensures array properties are populated)
            Assert.IsTrue(people.All(p => p.Films.Any()));
        }

        [TestMethod]
        public void GetAllStarships()
        {
            var ships = new StarWarsApiClient(HostOptions.Online).GetAllStarshipsAsync().Result;
            Assert.IsTrue(ships.Any());
        }

        [TestMethod]
        public void GetOnePerson()
        {
            var person = new StarWarsApiClient(HostOptions.Online).GetPersonAsync(1).Result;
            Assert.IsTrue(person.Name.Equals("Luke Skywalker"));
        }

        [TestMethod]
        public void GetOneStarship()
        {
            var ship = new StarWarsApiClient(HostOptions.Online).GetStarshipAsync(2).Result;
            Assert.IsTrue(ship.Name.Equals("CR90 corvette"));
        }

        [TestMethod]
        public void GetFilms()
        {
            var films = new StarWarsApiClient(HostOptions.Online).GetAsync<ApiResult<List<Film>>>("films/").Result;
            Assert.IsTrue(films.Data.Any());
        }

        [TestMethod]
        public void GetFilmAbsolute()
        {            
            var film = new StarWarsApiClient(HostOptions.Online).GetAsync<Film>("http://swapi.dev/api/films/1/").Result;
            Assert.IsTrue(film.Title.Equals("A New Hope"));
        }

        [TestMethod]
        public void GetObiWanAndFilms()
        {
            var client = new StarWarsApiClient(HostOptions.Online);
            var result = client.GetPersonAsync(10).Result;
            Assert.IsTrue(result.Name.Equals("Obi-Wan Kenobi"));
            Assert.IsTrue(result.Films.Length == 6);
        }
    }
}
