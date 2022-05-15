using Chapter09.Activity01.Bootstrap;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;

// DI
var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services
    .AddControllersConfiguration()
    .AddSwagger()
    .AddExceptionMappings(builder.Environment)
    .AddFileUploadService()
    .AddSecurity(builder.Configuration, builder.Environment);

var app = builder.Build();

// Middleware
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