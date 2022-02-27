using Microsoft.Extensions.DependencyInjection;

namespace Chapter09.Activity01.Bootstrap
{
    public static class ControllersConfigurationSetup
    {
        public static IServiceCollection AddControllersConfiguration(this IServiceCollection services)
        {
            services.AddControllers();
            return services;
        }
    }
}
