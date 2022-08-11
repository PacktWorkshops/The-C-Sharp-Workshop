using System;
using System.Globalization;
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
                .ForMember(to => to.Date, opt => opt.MapFrom(from => from.Datetime))
                .ForMember(to => to.Summary, opt => opt.MapFrom(from => from.Conditions))
                .ForMember(to => to.TemperatureC, opt => opt.MapFrom(from => (int)double.Parse(from.Temperature, CultureInfo.InvariantCulture)));
        }
    }
}