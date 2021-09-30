using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chapter09.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Chapter09.Service.Bootstrap
{
    public static class FileServiceSetup
    {
        public static IServiceCollection AddFileUploadService(this IServiceCollection services)
        {
            services.AddScoped<IFilesService, FilesService>();
            return services;
        }
    }
}
