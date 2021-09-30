using Hellang.Middleware.ProblemDetails;
using Microsoft.Extensions.DependencyInjection;

namespace Chapter09.Activity01.Bootstrap
{
    public static class ExceptionMappingSetup
    {
        public static IServiceCollection AddExceptionMappings(this IServiceCollection services)
        {
            services.AddProblemDetails();

            return services;
        }
    }
}