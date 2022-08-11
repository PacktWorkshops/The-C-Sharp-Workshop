using System;
using System.Threading.Tasks;
using AutoMapper;
using Chapter09.Service.Exceptions;
using Chapter09.Service.Models;
using Chapter09.Service.Providers;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Chapter09.Service.Services
{
    public interface IWeatherForecastService
    {
        WeatherForecast GetWeekday(int day);
        Task<WeatherForecast> GetWeatherForecast();
    }

    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly ILogger<WeatherForecastService> _logger;
        private readonly string _city;
        private readonly int _refreshInterval;
        private readonly Guid _serviceIdentifier;
        private readonly IMemoryCache _cache;
        private readonly IWeatherForecastProvider _provider;
        private readonly IMapper _mapper;

        public WeatherForecastService(ILogger<WeatherForecastService> logger, IOptions<WeatherForecastConfig> config, IMemoryCache cache, IWeatherForecastProvider provider, IMapper mapper)
        {
            _logger = logger;
            _city = config.Value.City;
            _refreshInterval = config.Value.RefreshInterval;
            _serviceIdentifier = Guid.NewGuid();
            _cache = cache;
            _provider = provider;
            _mapper = mapper;
        }

        public async Task<WeatherForecast> GetWeatherForecast()
        {
            const string DateFormat = "yyyy-MM-ddthh";
            var contains = _cache.TryGetValue(DateTime.UtcNow.ToString(DateFormat), out var entry);
            if (contains) { return (WeatherForecast)entry; }

            var forecastDto = await _provider.GetCurrent(_city);
            var forecast = _mapper.Map<WeatherForecast>(forecastDto);

            _cache.Set(DateTime.UtcNow.ToString(DateFormat), forecast);

            return forecast;
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
