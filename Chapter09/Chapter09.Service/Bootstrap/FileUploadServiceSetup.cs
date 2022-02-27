using Chapter09.Service.Exercises.Exercise03;
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
