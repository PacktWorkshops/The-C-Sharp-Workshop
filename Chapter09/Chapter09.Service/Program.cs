using Chapter09.Service.Bootstrap;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// DI
var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;
var environment = builder.Environment;

services
    .AddControllersConfiguration()
    .AddRequestValidators()
    .AddSwagger()
    .AddWeatherService(configuration)
    .AddExceptionMappings(environment)
    .AddHttpClients(configuration)
    .AddModelMappings()
    .AddFileUploadService()
    .AddSecurity(configuration, environment);

var app = builder.Build();

Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});

app.UseProblemDetails();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
