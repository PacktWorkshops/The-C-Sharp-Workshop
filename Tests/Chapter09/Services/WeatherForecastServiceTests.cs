namespace Tests.Chapter09.Services
{
    public class WeatherForecastServiceTests
    {
        //private readonly ILogger<WeatherForecastServiceTests> _logger;
        //private readonly string _city;
        //private readonly int _refreshInterval;
        //private readonly Guid _serviceIdentifier;
        //private readonly IMemoryCache _cache;
        //private readonly IWeatherForecastProvider _provider;
        //private readonly IMapper _mapper;

        //private const string DateFormat = "yyyy-MM-ddthh";

        //public WeatherForecastServiceTests(ILogger<WeatherForecastServiceTests> logger, IOptions<WeatherForecastConfig> config, IMemoryCache cache, IWeatherForecastProvider provider, IMapper mapper)
        //{
        //    _logger = logger;
        //    _city = config.Value.City;
        //    _refreshInterval = config.Value.RefreshInterval;
        //    _serviceIdentifier = Guid.NewGuid();
        //    _cache = cache;
        //    _provider = provider;
        //    _mapper = mapper;
        //}

        //public void SaveWeatherForecast(WeatherForecast forecast)
        //{
        //    _cache.Set(forecast.Date.ToString(DateFormat), forecast);
        //}

        //public async Task<WeatherForecast> GetWeatherForecast(DateTime date)
        //{
        //    var contains = _cache.TryGetValue(date.ToString(DateFormat), out var entry);
        //    if(contains){return (WeatherForecast)entry;}
            
        //    var forecastDto = await _provider.GetCurrent(_city);
        //    var forecast = _mapper.Map<WeatherForecast>(forecastDto);
        //    forecast.Date = DateTime.UtcNow;

        //    _cache.Set(DateTime.UtcNow.ToString(DateFormat), forecast);

        //    return forecast;
        //}

        //public WeatherForecast GetWeekday(int day)
        //{
        //    _logger.LogInformation(_serviceIdentifier.ToString());
        //    if(day < 1 || day > 7)
        //    {
        //        throw new NoSuchWeekdayException(day);
        //    }

        //    return new WeatherForecast();
        //}
    }
}
