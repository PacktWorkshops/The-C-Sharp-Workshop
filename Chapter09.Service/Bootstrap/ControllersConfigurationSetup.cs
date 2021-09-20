using FluentValidation.AspNetCore;
using Hellang.Middleware.ProblemDetails.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Chapter09.Service.Bootstrap
{
    public static class ControllersConfigurationSetup
    {
        public static IServiceCollection AddControllersConfiguration(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddFluentValidation();
            return services;
        }
    }
}
