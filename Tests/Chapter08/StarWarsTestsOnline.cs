using Chapter08;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Net.Http;

namespace Tests.Chapter08
{
    [TestClass]
    public class StarWarsTestsOnline
    {
        /// <summary>
        /// HttpClient should always be static due to subtleties about how it uses resources internally
        /// see https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client#create-and-initialize-httpclient
        /// </summary>
        static HttpClient _client = new HttpClient();

        [TestMethod]
        public void GetAllPeople()
        {
            var people = new StarWarsApiClient(_client, HostOptions.Online).GetAllPeopleAsync().Result;
            Assert.IsTrue(people.Any());
        }

        [TestMethod]
        public void GetAllStarships()
        {
            var ships = new StarWarsApiClient(_client, HostOptions.Online).GetAllStarshipsAsync().Result;
            Assert.IsTrue(ships.Any());
        }

        [TestMethod]
        public void GetOnePerson()
        {
            var person = new StarWarsApiClient(_client, HostOptions.Online).GetPersonAsync(1).Result;
            Assert.IsTrue(person.Name.Equals("Luke Skywalker"));
        }

        [TestMethod]
        public void GetOneStarship()
        {
            var ship = new StarWarsApiClient(_client, HostOptions.Online).GetStarshipAsync(2).Result;
            Assert.IsTrue(ship.Name.Equals("CR90 corvette"));
        }
    }
}
