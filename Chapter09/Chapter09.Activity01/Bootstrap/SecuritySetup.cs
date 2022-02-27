using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;

namespace Chapter09.Activity01.Bootstrap
{
    public static class SecuritySetup
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            var isTesting = string.Equals(
                env.EnvironmentName,
                "Testing",
                StringComparison.InvariantCultureIgnoreCase);
            if (isTesting)
            {
                IgnoreTokenValidation(services);
            }
            else
            {
                services.AddMicrosoftIdentityWebApiAuthentication(configuration);
            }

            return services;
        }

        private static void IgnoreTokenValidation(IServiceCollection services)
        {
            services
                    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = CreateTokenValidationParameters();
                    });
        }

        private static TokenValidationParameters CreateTokenValidationParameters()
        {
            var result = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = false,

                //IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey)),
                //comment this and add this line to fool the validation logic
                SignatureValidator = delegate (string token, TokenValidationParameters parameters)
                {
                    var jwt = new JwtSecurityToken(token);
                    return jwt;
                },

                RequireExpirationTime = false,
                ValidateLifetime = false,

                ClockSkew = TimeSpan.Zero,
            };

            result.RequireSignedTokens = false;

            return result;
        }
    }
}
