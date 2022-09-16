using System;
using System.Threading.Tasks;
using AutoMapper;
using Chapter09.Service.Dtos;
using Chapter09.Service.Exceptions;
using Chapter09.Service.Models;
using Chapter09.Service.Providers;
using Chapter09.Service.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Model = Chapter09.Service.Models;
using Dto = Chapter09.Service.Dtos;

namespace Tests.Chapter09.Services
{
    [TestClass]
    public class WeatherForecastServiceTests
    {
        private const string City = "Vilnius";
        private const int RefreshInterval = 1;
        private const string DateFormat = "yyyy-MM-ddthh";

        private WeatherForecastService _weatherForecastService;

        private Mock<ILogger<WeatherForecastService>> _logger;
        private Mock<IMemoryCache> _cache;
        private Mock<IWeatherForecastProvider> _provider;
        private Mock<IMapper> _mapper;

        [TestInitialize]
        public void SetUp()
        {
            _logger = new Mock<ILogger<WeatherForecastService>>();

            var entry = new Mock<ICacheEntry>();
            var weatherForecast = new Model.WeatherForecast();
            var expectedCacheKey = weatherForecast.Date.ToString(DateFormat);
            entry
                .SetupGet(e => e.Value)
                .Returns(weatherForecast);
            entry
                .SetupGet(e => e.Key)
                .Returns(expectedCacheKey);
            _cache = new Mock<IMemoryCache>();
            _cache
                .Setup(c => c.CreateEntry(It.IsAny<object>()))
                .Returns(entry.Object);

            _provider = new Mock<IWeatherForecastProvider>();
            _mapper = new Mock<IMapper>();

            _weatherForecastService = new WeatherForecastService(_logger.Object,
                Options.Create(new WeatherForecastConfig() { City = City, RefreshInterval = RefreshInterval }),
                _cache.Object,
                _provider.Object,
                _mapper.Object);
        }

        [TestMethod]
        public async Task GetWeatherForecast_GivenForecastAtDateExists_ReturnsForecast()
        {
            var expectedForecast = new Model.WeatherForecast() { Date = DateTime.UtcNow, Summary = "Ok", TemperatureC = 1 };
            var cachedForecast = (object)expectedForecast;
            var key = expectedForecast.Date.ToString(DateFormat);
            _cache
                .Setup(c => c.TryGetValue(key, out cachedForecast))
                .Returns(true);

            var forecast = await _weatherForecastService.GetWeatherForecast();

            Assert.AreEqual(cachedForecast, forecast);
            _cache.Verify(c => c.CreateEntry(key), Times.Never());
        }

        [TestMethod]
        public async Task GetWeatherForecast_GivenForecastAtDateDoesNotExist_SavesForecast_And_ReturnsIt()
        {
            var expectedForecast = new Model.WeatherForecast() { Date = DateTime.Now, Summary = "Ok", TemperatureC = 1 };
            var key = DateTime.UtcNow.ToString(DateFormat);

            object other = null;
            _cache
                .Setup(c => c.TryGetValue(key, out other))
                .Returns(false);

            var forecastDto = new Dto.WeatherForecast();
            _provider
                .Setup(p => p.GetCurrent(City))
                .ReturnsAsync(forecastDto);

            _mapper
                .Setup(m => m.Map<Model.WeatherForecast>(forecastDto))
                .Returns(expectedForecast);

            var forecast = await _weatherForecastService.GetWeatherForecast();

            Assert.AreEqual(forecast, expectedForecast);
            _cache.Verify(c => c.CreateEntry(key), Times.Once);
        }

        [DataRow(1)]
        [DataRow(7)]
        [DataRow(4)]
        [DataRow(3)]
        [DataTestMethod]
        public void GetWeekday_WhenInBetween1And7_ReturnsNewForecast(int day)
        {
            var forecast = _weatherForecastService.GetWeekday(day);

            Assert.IsNotNull(forecast);
        }

        [DataRow(0)]
        [DataRow(8)]
        [DataTestMethod]
        public void GetWeekday_WhenLessThan1OrMoreThan7_ThrowsNoSuchWeekdayException(int day)
        {
            Action getWeekdayOutOfRange = () => _weatherForecastService.GetWeekday(day);

            Assert.ThrowsException<NoSuchWeekdayException>(getWeekdayOutOfRange);
        }

    }
}
