using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests.Chapter09.NonFunctional.Common
{
    public class WebApplicationFactoryTesting<TClass> : WebApplicationFactory<TClass> where TClass : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("testing");
        }
    }
}
