using Chapter08;
using Chapter08.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests.Chapter08
{
    [TestClass]
    public class StringExtensionTests
    {
        /// <summary>
        /// shows a way to handle serialization of property names from 
        /// Star Wars API without adding [JsonPropertyName] everywhere
        /// </summary>
        [TestMethod]
        public void StarWarsPropertyNames()
        {
            var tests = new[]
            {
                new { input = nameof(Film.EpisodeId), output = "episode_id" },
                new { input = nameof(Film.OpeningCrawl), output = "opening_crawl" },
                new { input = nameof(Film.Title), output = "title" },
                new { input = nameof(Starship.CostInCredits), output = "cost_in_credits" }
            };

            var policy = new StarWarsNamingPolicy();
            Assert.IsTrue(tests.All(t => policy.ConvertName(t.input).Equals(t.output)));
        }
    }
}
