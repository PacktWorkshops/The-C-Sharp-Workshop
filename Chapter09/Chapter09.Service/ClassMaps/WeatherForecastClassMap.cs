using Chapter09.Service.Dtos;
using CsvHelper.Configuration;

namespace Chapter09.Service.ClassMaps
{
    public class WeatherForecastClassMap : ClassMap<WeatherForecast>
    {
        public WeatherForecastClassMap()
        {
            Map(m => m.Address).Name("Address");
            Map(m => m.Datetime).Name("Date time");
            Map(m => m.Latitude).Name("Latitude");
            Map(m => m.Longitude).Name("Longitude");
            Map(m => m.ResolvedAddress).Name("Resolved Address");
            Map(m => m.Name).Name("Name");
            Map(m => m.WindDirection).Name("Wind Direction");
            Map(m => m.Temperature).Name("Temperature");
            Map(m => m.WindSpeed).Name("Wind Speed");
            Map(m => m.CloudCover).Name("Cloud Cover");
            Map(m => m.HeatIndex).Name("Heat Index");
            Map(m => m.ChancePrecipitation).Name("Chance Precipitation (%)");
            Map(m => m.Precipitation).Name("Precipitation");
            Map(m => m.SeaLevelPressure).Name("Sea Level Pressure");
            Map(m => m.SnowDepth).Name("Snow Depth");
            Map(m => m.Snow).Name("Snow");
            Map(m => m.RelativeHumidity).Name("Relative Humidity");
            Map(m => m.WindGust).Name("Wind Gust");
            Map(m => m.WindChill).Name("Wind Chill");
            Map(m => m.Conditions).Name("Conditions");
        }
    }
}
