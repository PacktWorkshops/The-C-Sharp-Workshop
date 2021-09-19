using System;
using System.IO;
using System.Reflection;
using Chapter09.Service.Exercises.Exercise02;
using Chapter09.Service.Services;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Chapter09.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddConsole();
                builder.AddDebug();
            });
            
            services.AddScoped<IWeatherForecastService, WeatherForecastService>(BuildWeatherForecastService);
            services.AddSingleton<ICurrentTimeProvider, CurrentTimeUtcProvider>();
            services.AddSingleton<IMemoryCache, MemoryCache>();

            services.AddSwaggerGen(cfg =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                cfg.IncludeXmlComments(xmlPath);
            });


        }

        //public static void AddExceptionToStatusCodeMappings(this IServiceCollection services)
        //{
        //    services
        //        .Map<NotSupportedException>(400);
        //}

        //private static IServiceCollection Map<TException>(this IServiceCollection services, int statusCode) where TException : Exception
        //{
        //    services.AddProblemDetails(opt => opt.MapToStatusCode<TException>(statusCode));

        //    return services;
        //}

        private WeatherForecastService BuildWeatherForecastService(IServiceProvider provider)
        {
            var logger = provider
                .GetService<ILoggerFactory>()
                .CreateLogger<WeatherForecastService>();
            return new WeatherForecastService(logger, "New York", 5, provider.GetService<IMemoryCache>());
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseRouting();
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
