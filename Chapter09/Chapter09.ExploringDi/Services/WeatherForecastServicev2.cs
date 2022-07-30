using System;
using Chapter09.Service.Exceptions;
using Chapter09.Service.Models;
using Microsoft.Extensions.Logging;

namespace Chapter09.Service.Services
{
    public class WeatherForecastServiceV2 : IWeatherForecastService
    {
        private readonly string _city;
        private readonly int _refreshInterval;

        public WeatherForecastServiceV2(string city, int refreshInterval)
        {
            _city = city;
            _refreshInterval = refreshInterval;
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
