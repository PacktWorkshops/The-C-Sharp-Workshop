using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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

        //[HttpGet("weekday/{day}")]
        //public IActionResult GetWeekday(int day)
        //{
        //    var result = _weatherForecastService1.GetWeekday(day);
        //    result = _weatherForecastService2.GetWeekday(day);
        //    return Ok(result);
        //}

        ///// <summary>
        ///// Gets weather forecast for now.
        ///// </summary>
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetWeatherForecast()
        //{
        //    var weatherForecast = await _weatherForecastService1.GetWeatherForecast(DateTime.UtcNow);
        //    if (weatherForecast == null) return NotFound();
        //    return Ok(weatherForecast);
        //}

        ///// <summary>
        ///// Saves a forecast at forecast date.
        ///// </summary>
        ///// <param name="weatherForecast">Date which identifies a forecast. Using short date time string for identity.</param>
        ///// <returns>201 with a link to an action to fetch a created forecast.</returns>
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //public IActionResult SaveWeatherForecast(WeatherForecast weatherForecast)
        //{
        //    _weatherForecastService1.SaveWeatherForecast(weatherForecast);
        //    return CreatedAtAction("GetWeatherForecast", new { date = weatherForecast.Date.ToShortDateString() }, weatherForecast);
        //}
    }
}
