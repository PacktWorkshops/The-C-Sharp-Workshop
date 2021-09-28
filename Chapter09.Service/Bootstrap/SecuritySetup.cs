using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;

namespace Chapter09.Service.Bootstrap
{
    public static class SecuritySetup
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {

                });
                //.AddMicrosoftIdentityWebApi(options =>
                //{
                //    configuration.Bind("AzureAd", options);
                //    options.TokenValidationParameters.ValidateAudience = false;
                //    options.Events = new JwtBearerEvents();
                //    options.Events.OnAuthenticationFailed += OnAuthenticationFailed;
                //    options.Events.OnForbidden += OnForbidden;
                //    options.Events.OnTokenValidated += OnTokenValidated;
                //}, options =>
                //{
                //    configuration.Bind("AzureAd", options);
                //    options.AllowWebApiToBeAuthorizedByACL = true;
                //}, subscribeToJwtBearerMiddlewareDiagnosticsEvents: true);
            return services;
        }

        private static Task OnTokenValidated(TokenValidatedContext arg)
        {
            return Task.CompletedTask;
        }

        private static Task OnForbidden(ForbiddenContext arg)
        {
            return Task.CompletedTask;
        }

        private static Task OnAuthenticationFailed(AuthenticationFailedContext arg)
        {
            return Task.CompletedTask;
        }
    }
}
