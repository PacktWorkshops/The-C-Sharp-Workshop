using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Chapter09.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // To run a different example, use a different startup.
                    webBuilder.UseStartup<Startup>();
                });
    }
}
