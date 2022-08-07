using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chapter09.Service.Models;
using Chapter09.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using WeatherForecast = Chapter09.Service.Dtos.WeatherForecast;

namespace Chapter09.Service.Controllers
{
    //[Authorize]
    [ApiController]
    [RequiredScope("access_as_user")]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly ILogger _logger;

        public WeatherForecastController(ILoggerFactory logger, IWeatherForecastService weatherForecastService, IWeatherForecastService weatherForecastService2)
        {
            _weatherForecastService = weatherForecastService;
            _logger = logger.CreateLogger(typeof(WeatherForecastController).FullName);
        }

        [HttpGet("error")]
        public IEnumerable<WeatherForecast> GetError()
        {
            _logger.LogError("Whoops");
            throw new Exception("Something went wrong");
        }

        [HttpGet("weekday/{day}")]
        public IActionResult GetWeekday(int day)
        {
            var result = _weatherForecastService.GetWeekday(day);
            return Ok(result);
        }

        /// <summary>
        /// Gets weather forecast for now.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWeatherForecast()
        {
            var weatherForecast = await _weatherForecastService.GetWeatherForecast();
            return Ok(weatherForecast);
        }
    }
}
