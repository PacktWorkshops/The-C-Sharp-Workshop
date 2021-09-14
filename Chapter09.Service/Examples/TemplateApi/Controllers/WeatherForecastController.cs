using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Chapter09.Service.Examples.TemplateApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger _logger;

        public WeatherForecastController(ILoggerFactory logger)
        {
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
            if (day < 1 || day > 7)
            {
                return NotFound($"'{day}' is not a valid day of a week.");
            }

            return Ok(new WeatherForecast());
        }
    }
}
