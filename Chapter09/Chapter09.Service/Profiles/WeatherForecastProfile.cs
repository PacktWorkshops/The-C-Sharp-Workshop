using System;
using System.Linq;
using AutoMapper;
using Chapter09.Service.Dtos;

namespace Chapter09.Service.Profiles
{
    public class WeatherForecastProfile : Profile
    {
        public WeatherForecastProfile()
        {
            CreateMap<Dtos.WeatherForecast, Models.WeatherForecast>()
                .ForMember(to => to.Summary, opt => opt.MapFrom(from => BuildDescription(from)))
                .ForMember(to => to.TemperatureC, opt => opt.MapFrom(from => (int)double.Parse(from.Temperature)));
        }

        private string BuildDescription(WeatherForecast @from)
        {
            return $"{@from.Conditions} | {@from.CloudCover} | {@from.Name}";
        }
    }
}