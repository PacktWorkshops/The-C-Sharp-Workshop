using Chapter09.ExploringDi.Exceptions;
using Chapter09.ExploringDi.Models;

namespace Chapter09.ExploringDi.Services
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
