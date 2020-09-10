using Chapter08;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests.Chapter08
{
    [TestClass]
    public class StarWarsTests
    {
        [TestMethod]
        public void GetAllPeople()
        {
            var people = StarWars.GetAllPeopleAsync().Result;
            Assert.IsTrue(people.Any());
        }

        [TestMethod]
        public void GetOnePerson()
        {
            var person = StarWars.GetPersonAsync(1).Result;
            Assert.IsTrue(person.Name.Equals("Luke Skywalker"));
        }
    }
}
