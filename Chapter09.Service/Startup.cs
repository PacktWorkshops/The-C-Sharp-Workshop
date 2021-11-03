using System;
using Chapter09.Service.Bootstrap;
using Chapter09.Service.Models;
using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chapter09.Service
{
    public class Startup
    {
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
                .AddRequestValidators()
                .AddSwagger()
                .AddWeatherService(Configuration)
                .AddExceptionMappings(Environment)
                .AddHttpClients(Configuration)
                .AddModelMappings()
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

    public class WeatherForecastValidator : AbstractValidator<WeatherForecast>
    {
        public WeatherForecastValidator()
        {
            RuleFor(p => p.Date)
                .LessThan(DateTime.Now.AddMonths(1))
                .WithMessage("Weather forecasts in more than 1 month of future are not supported");

            RuleFor(p => p.TemperatureC)
                .InclusiveBetween(-100, 100)
                .WithMessage("A temperature must be between -100 and +100 C.");
        }
    }
}
