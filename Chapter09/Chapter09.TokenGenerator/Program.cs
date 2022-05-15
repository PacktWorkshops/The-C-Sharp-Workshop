using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

var application = BuildAadClientApplication();
var token = await GetTokenUsingPersonalAuth(application);
Console.WriteLine($"Bearer {token}");

static IPublicClientApplication BuildAadClientApplication()
{
    // Uncomment either (double check whether they match your AAD values).
    //const string clientId = "0aabad2a-a997-4cc7-b750-56d905e28d8d"; // Activity01
    // const string clientId = "2d8834d3-6a27-47c9-84f1-0c9db3eeb4bb";
    const string clientId = "2d8834d3-6a27-47c9-84f1-0c9db3eeb4bb"; // Service
    const string tenantId = "ddd0fd18-f056-4b33-88cc-088c47b81f3e";
    const string redirectUri = "http://localhost:5002/token";
    string authority = string.Concat("https://login.microsoftonline.com/", tenantId);

    var application = PublicClientApplicationBuilder.Create(clientId)
        .WithAuthority(authority)
        .WithRedirectUri(redirectUri)
        .Build();

    return application;
}

// Requires the same login as Azure portal.
// Upon successful login - return auth token.
static async Task<string> GetTokenUsingPersonalAuth(IPublicClientApplication application)
{
    // Replace this with your own application id uri if you are not using a default value.
    const string scope = "access_as_user";
    var scopes = new[] { $"api://{application.AppConfig.ClientId}/{scope}" };

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
