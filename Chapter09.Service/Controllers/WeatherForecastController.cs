using System;
using System.Collections.Generic;
using Chapter09.Service.Exceptions;
using Chapter09.Service.Models;
using Chapter09.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Chapter09.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly ILogger _logger;

        public WeatherForecastController(ILoggerFactory logger, IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
            _logger = logger.CreateLogger(typeof(WeatherForecastController).FullName);
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return new List<WeatherForecast>(){new WeatherForecast()};
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
            try
            {
                var result = _weatherForecastService.GetWeekday(day);
                return Ok(result);
            }
            catch(NoSuchWeekdayException exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}
