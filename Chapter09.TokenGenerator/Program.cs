using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Chapter09.TokenGenerator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var token = await GetAuthorizationToken();
            Console.WriteLine($"Bearer {token}");
        }

        private static async Task<string> GetAuthorizationToken()
        {
            // Replace this with your own variables from AAD:
            const string tenantId = "ddd0fd18-f056-4b33-88cc-088c47b81f3e";
            const string clientId = "2d8834d3-6a27-47c9-84f1-0c9db3eeb4bb";
            const string scope = "access_as_user";
            const string redirectUri = "http://localhost:5002/token";
            string authority = string.Concat("https://login.microsoftonline.com/", tenantId);

            var application = PublicClientApplicationBuilder.Create(clientId)
                .WithAuthority(authority)
                .WithRedirectUri(redirectUri)
                .Build();

            // Replace this with your own application id uri if you are not using a default value.
            var scopes = new[] { $"api://{clientId}/{scope}" };

            AuthenticationResult result;
            try
            {
                var accounts = await application.GetAccountsAsync();
                result = await application.AcquireTokenSilent(scopes, accounts.FirstOrDefault()).ExecuteAsync();
            }
            catch (MsalUiRequiredException ex)
            {
                result = await application.AcquireTokenInteractive(scopes)
                    .WithClaims(ex.Claims)
                    .ExecuteAsync();
            }

            return result.AccessToken;
        }
    }
}
