using System.Linq;
using AutoMapper;

namespace Chapter09.Service.Profiles
{
    public class WeatherForecastProfile : Profile
    {
        public WeatherForecastProfile()
        {
            CreateMap<Dtos.WeatherForecast, Models.WeatherForecast>()
                .ForMember(to => to.Summary, opt => opt.MapFrom(from => BuildDescription(from)))
                .ForMember(to => to.TemperatureC, opt => opt.MapFrom(from => from.main.temp));
        }

        private static string BuildDescription(Dtos.WeatherForecast forecast)
        {
            return string.Join(",",
                forecast.weather.Select(w => w.description));
        }
    }
}