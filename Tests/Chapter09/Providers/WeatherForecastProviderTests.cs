using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Chapter09.Service.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichardSzalay.MockHttp;

namespace Tests.Chapter09.Providers
{
    [TestClass]
    public class WeatherForecastProviderTests
    {
        private HttpClient _client;

        [TestInitialize]
        public void SetUp()
        {
            _client = new HttpClient {BaseAddress = new Uri("https://community-open-weather-map.p.rapidapi.com/") };
            var apiKey = Environment.GetEnvironmentVariable("x-rapidapi-key", EnvironmentVariableTarget.User);
            _client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);
        }

        [TestCleanup]
        public void TearDown()
        {
            _client.Dispose();
        }

        [TestMethod]
        public async Task GetCurrent_WhenVilnius_ReturnsSomeForecast()
        {
            var forecastProvider = new WeatherForecastProvider(_client);

            var forecast = await forecastProvider.GetCurrent("Vilnius");

            Assert.IsTrue(forecast.weather.Any(), "Expected one or more weather forecasts");
        }
    }
}
