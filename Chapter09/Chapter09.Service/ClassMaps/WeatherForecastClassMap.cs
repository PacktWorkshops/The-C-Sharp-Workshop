using Chapter09.Service.Dtos;
using CsvHelper.Configuration;

namespace Chapter09.Service.ClassMaps
{
    public class WeatherForecastClassMap : ClassMap<WeatherForecast>
    {
        public WeatherForecastClassMap()
        {
            Map(m => m.Datetime).Name("Date time");
            Map(m => m.Temperature).Name("Temperature");
            Map(m => m.Conditions).Name("Conditions");
        }
    }
}
