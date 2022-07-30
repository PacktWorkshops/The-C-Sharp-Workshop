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
        private readonly IWeatherForecastService _weatherForecastService1;
        private readonly IWeatherForecastService _weatherForecastService2;
        private readonly ILogger _logger;

        public WeatherForecastController(ILoggerFactory logger, IWeatherForecastService weatherForecastService1, IWeatherForecastService weatherForecastService2)
        {
            _weatherForecastService1 = weatherForecastService1;
            _weatherForecastService2 = weatherForecastService2;
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
            try
            {
                var result = _weatherForecastService1.GetWeekday(day);
                result = _weatherForecastService1.GetWeekday(day);
                return Ok(result);
            }
            catch (NoSuchWeekdayException exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}
