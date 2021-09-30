using Chapter09.Activity01.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Chapter09.Activity01.Bootstrap
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
