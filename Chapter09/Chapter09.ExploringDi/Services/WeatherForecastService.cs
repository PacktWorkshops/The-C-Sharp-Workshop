using System;
using Chapter09.ExploringDi.Exceptions;
using Chapter09.ExploringDi.Models;
using Microsoft.Extensions.Logging;

namespace Chapter09.ExploringDi.Services
{
    public interface IWeatherForecastService
    {
        WeatherForecast GetWeekday(int day);
    }


    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly ILogger<WeatherForecastService> _logger;

        public WeatherForecastService(ILogger<WeatherForecastService> logger)
        {
            _logger = logger;
            _logger.LogInformation(Guid.NewGuid().ToString());
        }

        public WeatherForecast GetWeekday(int day)
        {
            if (day < 1 || day > 7)
            {
                throw new NoSuchWeekdayException(day);
            }

            return new WeatherForecast();
        }
    }
}
