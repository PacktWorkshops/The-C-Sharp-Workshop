using Chapter08.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Chapter08
{
    [TestClass]
    public class StarWarsRestSharp
    {
        [TestMethod]
        public void GetStarships()
        {
            var client = new RestClient("https://swapi.dev/api/");
            //client.UseSystemTextJson();
            client.UseNewtonsoftJson();
            var request = new RestRequest("starships/");                      
            var response = client.GetAsync<ApiResult<List<Starship>>>(request).Result;
            Assert.IsTrue(response.Data.Count == 10);
            // at least one ship has at least one pilot
            Assert.IsTrue(response.Data.Any(st => st.Pilots.Any()));
        }
    }
}
