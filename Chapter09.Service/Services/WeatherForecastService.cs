using System;
using Chapter09.Service.Exceptions;
using Chapter09.Service.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Chapter09.Service.Services
{
    public interface IWeatherForecastService
    {
        WeatherForecast GetWeekday(int day);
        void SaveWeatherForecast(WeatherForecast forecast);
        WeatherForecast GetWeatherForecast(DateTime date);
    }

    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly ILogger<WeatherForecastService> _logger;
        private readonly string _city;
        private readonly int _refreshInterval;
        private readonly Guid _serviceIdentifier;
        private readonly IMemoryCache _cache;

        public WeatherForecastService(ILogger<WeatherForecastService> logger, IOptions<WeatherForecastConfig> config, IMemoryCache cache)
        {
            _logger = logger;
            _city = config.Value.City;
            _refreshInterval = config.Value.RefreshInterval;
            _serviceIdentifier = Guid.NewGuid();
            _cache = cache;
        }

        public void SaveWeatherForecast(WeatherForecast forecast)
        {
            _cache.Set(forecast.Date.ToShortDateString(), forecast);
        }

        public WeatherForecast GetWeatherForecast(DateTime date)
        {
            var shortDateString = date.ToShortDateString();
            var contains = _cache.TryGetValue(shortDateString, out var entry);
            return !contains ? null : (WeatherForecast) entry;
        }

        public WeatherForecast GetWeekday(int day)
        {
            _logger.LogInformation(_serviceIdentifier.ToString());
            if(day < 1 || day > 7)
            {
                throw new NoSuchWeekdayException(day);
            }

            return new WeatherForecast();
        }
    }
}
