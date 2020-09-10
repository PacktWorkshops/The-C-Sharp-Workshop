using Chapter08;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using static Chapter08.StarWarsApiClient;

namespace Tests.Chapter08
{
    [TestClass]
    public class StarWarsTests
    {
        [TestMethod]
        public void GetAllPeople()
        {
            var people = new StarWarsApiClient(BackEndOptions.Public).GetAllPeopleAsync().Result;
            Assert.IsTrue(people.Any());
        }

        [TestMethod]
        public void GetAllStarships()
        {
            var ships = new StarWarsApiClient(BackEndOptions.Public).GetAllStarshipsAsync().Result;
            Assert.IsTrue(ships.Any());
        }

        [TestMethod]
        public void GetOnePerson()
        {
            var person = new StarWarsApiClient(BackEndOptions.Public).GetPersonAsync(1).Result;
            Assert.IsTrue(person.Name.Equals("Luke Skywalker"));
        }

        [TestMethod]
        public void GetOneStarship()
        {
            var ship = new StarWarsApiClient(BackEndOptions.Public).GetStarshipAsync(2).Result;
            Assert.IsTrue(ship.Name.Equals("CR90 corvette"));
        }
    }
}
