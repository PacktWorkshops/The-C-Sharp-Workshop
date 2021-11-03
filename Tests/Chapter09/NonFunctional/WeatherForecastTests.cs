using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Chapter09.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Tests.Chapter09.NonFunctional.Common;

namespace Tests.Chapter09.NonFunctional
{
    [TestClass]
    public class WeatherForecastControllerTests
    {
        private static HttpClient _client;

        [TestInitialize]
        public void SetUp()
        {
            _client = Chapter09ApiFixture.ClientApi;
        }

        [TestMethod]
        public async Task GetError_Returns500()
        {
            var response = await _client.GetAsync(new Uri("error/", UriKind.Relative));

            var content = await response.Content.ReadAsStringAsync();
            var problem = JsonConvert.DeserializeObject<ProblemDetails>(content);
            Assert.AreEqual(500, problem.Status);
            Assert.AreEqual("Something went wrong", problem.Detail);
        }

        [DataRow(1)]
        [DataRow(7)]
        [DataRow(4)]
        [DataRow(3)]
        [DataTestMethod]
        public async Task GetWeekday_WhenInBetween1And7_ReturnsNewForecast(int day)
        {
            var response = await _client.GetAsync(new Uri($"weekday/{day}/", UriKind.Relative));

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [DataRow(0)]
        [DataRow(8)]
        [DataTestMethod]
        public async Task GetWeekday_WhenLessThan1OrMoreThan7_ThrowsNoSuchWeekdayException(int day)
        {
            var response = await _client.GetAsync(new Uri($"weekday/{day}/", UriKind.Relative));

            var content = await response.Content.ReadAsStringAsync();
            var problem = JsonConvert.DeserializeObject<ProblemDetails>(content);
            Assert.AreEqual(404, problem.Status);
            Assert.AreEqual($"'{day}' is not a valid day of a week.", problem.Detail);
        }

        [TestMethod]
        public async Task GetWeatherForecast_ReturnsVilniusForecast()
        {
            var response = await _client.GetAsync(new Uri("", UriKind.Relative));

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            var forecast = JsonConvert.DeserializeObject<WeatherForecast>(content);
            Assert.IsNotNull(forecast);
        }

        [TestMethod]
        public async Task SaveWeatherForecast_ReturnsVilniusForecast()
        {
            var uri = new Uri("", UriKind.Relative);
            var forecast = new WeatherForecast {Summary = "Test" };
            var body = JsonContent.Create(forecast);
            var response = await _client.PostAsync(uri,body);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            var retrievedForecast = JsonConvert.DeserializeObject<WeatherForecast>(content);
            Assert.IsNotNull(forecast.Summary, retrievedForecast.Summary);
        }
    }
}
