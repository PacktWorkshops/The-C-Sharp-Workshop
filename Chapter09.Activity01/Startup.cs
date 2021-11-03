using System;
using Chapter09.Activity01.Bootstrap;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chapter09.Activity01
{
    public class Startup
    {
        public static string Message = "";

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllersConfiguration()
                .AddSwagger()
                .AddExceptionMappings(Environment)
                .AddFileUploadService()
                .AddSecurity(Configuration, Environment);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;

            app.UseProblemDetails();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
