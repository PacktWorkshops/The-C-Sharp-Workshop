using System;
using Chapter09.Service.Exercises.Exercise02;
using Chapter09.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            
            services.AddSingleton<IWeatherForecastService, WeatherForecastService>(BuildWeatherForecastService);
            services.AddSingleton<ICurrentTimeProvider, CurrentTimeUtcProvider>();
            //Debug.WriteLine("Services count: " + services.Count);
            //services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
            //Debug.WriteLine("Services count: " + services.Count);

            //services.TryAddSingleton<IWeatherForecastService, WeatherForecastService>();
            //Debug.WriteLine("Services count: " + services.Count);
            //services.TryAddSingleton<IWeatherForecastService, WeatherForecastService>();
            //Debug.WriteLine("Services count: " + services.Count);
        }

        private WeatherForecastService BuildWeatherForecastService(IServiceProvider provider)
        {
            var logger = provider
                .GetService<ILoggerFactory>()
                .CreateLogger<WeatherForecastService>();
            return new WeatherForecastService(logger, "New York", 5);
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
        }
    }
}
