using Chapter09.Service.Models;
using Chapter09.Service.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Chapter09.Service.Bootstrap
{
    public static class RequestValidatorsSetup
    {
        public static IServiceCollection AddRequestValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<WeatherForecast>, WeatherForecastValidator>();
            return services;
        }
    }
}