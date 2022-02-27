using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Chapter09.Service.Bootstrap
{
    public static class LoggingSetup
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddConsole();
                builder.AddDebug();
            });
            return services;
        }
    }
}
