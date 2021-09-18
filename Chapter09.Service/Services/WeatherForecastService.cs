using System;
using Chapter09.Service.Exceptions;
using Chapter09.Service.Models;
using Microsoft.Extensions.Logging;

namespace Chapter09.Service.Services
{
    public interface IWeatherForecastService
    {
        WeatherForecast GetWeekday(int day);
    }

    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly ILogger<WeatherForecastService> _logger;
        private readonly string _city;
        private readonly int _refreshInterval;
        private readonly Guid _serviceIdentifier;

        public WeatherForecastService(ILogger<WeatherForecastService> logger, string city, int refreshInterval)
        {
            _logger = logger;
            _city = city;
            _refreshInterval = refreshInterval;
            _serviceIdentifier = Guid.NewGuid();
        }

        public WeatherForecast GetWeekday(int day)
        {
            _logger.LogInformation(_serviceIdentifier.ToString());
            if (day < 1 || day > 7)
            {
                throw new NoSuchWeekdayException(day);
            }

            return new WeatherForecast();
        }
    }
}
