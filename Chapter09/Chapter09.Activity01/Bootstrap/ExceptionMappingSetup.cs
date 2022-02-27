using System;
using System.IO;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Chapter09.Activity01.Bootstrap
{
    public static class ExceptionMappingSetup
    {
        public static IServiceCollection AddExceptionMappings(this IServiceCollection services,
            IWebHostEnvironment env)
        {
            services.AddProblemDetails(opt =>
            {
                opt.MapToStatusCode<FileNotFoundException>(404);
                opt.IncludeExceptionDetails = (_, __) => env.IsDevelopment() ||
                                                         string.Equals(env.EnvironmentName, "testing", StringComparison.InvariantCultureIgnoreCase);
            });

            return services;
        }
    }
}