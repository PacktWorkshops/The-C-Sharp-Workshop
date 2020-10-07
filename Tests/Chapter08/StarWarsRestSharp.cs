using Chapter08.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Serializers.SystemTextJson;
using System.Collections.Generic;

namespace Tests.Chapter08
{
    [TestClass]
    public class StarWarsRestSharp
    {
        [TestMethod]
        public void GetStarships()
        {
            var client = new RestClient("https://swapi.dev/api/");
            client.UseSystemTextJson();
            var request = new RestRequest("starships/");
            var response = client.GetAsync<ApiResult<List<Starship>>>(request).Result;
            Assert.IsTrue(response.Data.Count == 10);
        }
    }
}
