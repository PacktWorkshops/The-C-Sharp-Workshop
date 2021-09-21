using System;
using Chapter09.Service.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chapter09.Service.Bootstrap
{
    public static class HttpClientsSetup
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient<IWeatherForecastProvider, WeatherForecastProvider>(client =>
            {
                client.BaseAddress = new Uri(config["WeatherForecastProviderUrl"]);
                var apiKey = Environment.GetEnvironmentVariable("x-rapidapi-key", EnvironmentVariableTarget.User);
                client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);
            });

            return services;
        }
    }
}
