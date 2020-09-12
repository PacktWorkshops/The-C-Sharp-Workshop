using Chapter08;
using Chapter08.Models;
using Chapter08.Service.Static;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Net.Http;

namespace Tests.Chapter08
{
    [TestClass]
    public class StarWarsTestsLocal
    {
        /// <summary>
        /// HttpClient should always be static due to subtleties about how it uses resources internally
        /// see https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client#create-and-initialize-httpclient
        /// </summary>
        static HttpClient _client = new HttpClient();

        /// <summary>
        /// before running this, launch an instance of Chapter08.Service (set project as startup, press Ctrl+F5 to start without debugger)
        /// </summary>
        [TestMethod]
        public void ImportPeople()
        {
            JsonFiles.DeleteAllFiles<Person>();
           
            var onlineClient = new StarWarsApiClient(_client, HostOptions.Online);
            var localClient = new StarWarsApiClient(_client, HostOptions.Local);

            var onlinePeople = onlineClient.GetAllPeopleAsync().Result;
            foreach (var p in onlinePeople) localClient.CreatePerson(p).Wait();

            var localPeople = localClient.GetAllPeopleAsync().Result;
            Assert.IsTrue(onlinePeople.Count().Equals(localPeople.Count()));
        }
    }
}
