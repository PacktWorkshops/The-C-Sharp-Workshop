using Chapter08.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;

namespace Tests.Chapter08
{
    [TestClass]
    public class WorldTimeTests
    {
        private static HttpClient _client = new HttpClient()
        {
            BaseAddress = new Uri("http://worldtimeapi.org/api/")
        };

        [TestMethod]
        public void GetCurrentDateTime()
        {
            var client = new WorldTimeClient(_client);
            var result = client.GetCurrentDateTime().Result;
            // if no exception, then test passes
        }
    }
}
