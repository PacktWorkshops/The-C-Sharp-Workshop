using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Chapter09.Service.Bootstrap
{
    public static class ControllersConfigurationSetup
    {
        public static IServiceCollection AddControllersConfiguration(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddFluentValidation()
                .AddNewtonsoftJson();
            return services;
        }
    }
}
