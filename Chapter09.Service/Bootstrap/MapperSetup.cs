using Chapter09.Service.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Chapter09.Service.Bootstrap
{
    public static class MapperSetup
    {
        public static IServiceCollection AddModelMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<WeatherForecastProfile>();
            });

            return services;
        }
    }
}