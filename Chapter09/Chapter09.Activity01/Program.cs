using System;
using Chapter09.Activity01.Bootstrap;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Add services
var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services
    .AddControllersConfiguration()
    .AddSwagger()
    .AddExceptionMappings(builder.Environment)
    .AddFileUploadService()
    .AddSecurity(builder.Configuration, builder.Environment);

var app = builder.Build();


// Add middleware
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

//app.UseSwagger();
//app.UseSwaggerUI(c =>
//{
//    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
//    c.RoutePrefix = string.Empty;
//});