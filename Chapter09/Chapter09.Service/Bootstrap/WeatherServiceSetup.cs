using System;
using AutoMapper;
using Chapter09.Service.Exercises.Exercise02;
using Chapter09.Service.Models;
using Chapter09.Service.Providers;
using Chapter09.Service.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Chapter09.Service.Bootstrap
{
    public static class WeatherServiceSetup
    {
        public static IServiceCollection AddWeatherService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IWeatherForecastService, WeatherForecastService>(BuildWeatherForecastService);
            services.AddSingleton<ICurrentTimeProvider, CurrentTimeUtcProvider>();
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.Configure<WeatherForecastConfig>(configuration.GetSection(nameof(WeatherForecastConfig)));
            return services;
        }

        private static WeatherForecastService BuildWeatherForecastService(IServiceProvider provider)
        {
            var logger = provider
                .GetService<ILoggerFactory>()
                .CreateLogger<WeatherForecastService>();
            var options = provider.GetService<IOptions<WeatherForecastConfig>>();
            return new WeatherForecastService(
                logger,
                options,
                provider.GetService<IMemoryCache>(),
                provider.GetService<IWeatherForecastProvider>(),
                provider.GetService<IMapper>());
        }
    }
}