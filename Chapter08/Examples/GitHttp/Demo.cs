using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Chapter08.Examples.GitHttp
{
    public static class Demo
    {
        private static string GitHubClientId { get; } = Environment.GetEnvironmentVariable("GithubClientId", EnvironmentVariableTarget.User);
        private static string GitHubSecret { get; } = Environment.GetEnvironmentVariable("GithubSecret", EnvironmentVariableTarget.User);


        private static HttpClient client;

        static Demo()
        {
            client = new HttpClient { BaseAddress = new Uri("https://api.github.com") };
            client.DefaultRequestHeaders.Add("User-Agent", "Packt");
        }

        public static async Task Run()
        {
            //await GetUser();

            //var oathAccessToken = await GetToken();
            //await UpdateEmploymentStatus(true, oathAccessToken);

            //var personalAccessToken = Program.GitHubPersonAccessToken;
            //await UpdateEmploymentStatus(false, personalAccessToken);

            var basicToken = GetBasicToken();
            await GetUser61Times(basicToken);
        }

        private static async Task GetUser()
        {
            const string username = "almantask";
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri($"users/{username}", UriKind.Relative));

            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(content);

            Console.WriteLine($"{user.Name} created profile at {user.CreatedAt}");
        }

        // GitHub limits rate of requests:
        // - unauthenticated requests to 60/h per IP.
        // - 5000 authenticated requests
        // If header wasn't working, we should be rate limited
        // This method proves that the basic auth works and we follow authenticated rate limit.
        private static async Task GetUser61Times(string authHeader)
        {
            const int rateLimit = 60;
            for (int i = 0; i < rateLimit + 1; i++)
            {
                const string username = "almantask";
                var request = new HttpRequestMessage(HttpMethod.Get, new Uri($"users/{username}", UriKind.Relative));
                request.Headers.CacheControl = new CacheControlHeaderValue(){NoCache = true};
                request.Headers.Add("Authorization", authHeader);

                var response = await client.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

                var content = await response.Content.ReadAsStringAsync();
                
                var user = JsonConvert.DeserializeObject<User>(content);

                Console.WriteLine($"{i+1}) {user.Name} created profile at {user.CreatedAt}");
            }
        }

        private static async Task<string> GetToken()
        {
            HttpRequestMessage request = CreateGetAccessTokenRequest();

            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            Dictionary<string, string> tokenResponse = ConvertToDictionary(content);

            ValidateNoError(tokenResponse);

            var token = $"{tokenResponse["token_type"]} {tokenResponse["access_token"]}";
            return token;
        }

        private static HttpRequestMessage CreateGetAccessTokenRequest()
        {
            const string tokenUrl = "https://github.com/login/oauth/access_token";
            const string code = "2ecab6ecf412f28f7d4d";
            const string redirectUri = "https://www.google.com/";
            var uri = new Uri($"{tokenUrl}?client_id={GitHubClientId}&redirect_uri={redirectUri}&client_secret={GitHubSecret}&code={code}");
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            return request;
        }

        private static Dictionary<string, string> ConvertToDictionary(string content)
        {
            return content
                .Split('&')
                .Select(kvp => kvp.Split('='))
                .Where(kvp => kvp.Length > 1)
                .ToDictionary(kvp => kvp[0], kvp => kvp[1]);
        }

        private static void ValidateNoError(Dictionary<string, string> tokenResponse)
        {
            if (tokenResponse.ContainsKey("error"))
            {
                throw new Exception(
                    $"{tokenResponse["error"].Replace("_", " ")}. " +
                    $"{tokenResponse["error_description"].Replace("+", " ")}");
            }
        }

        private static async Task UpdateEmploymentStatus(bool isHireable, string authToken)
        {
            var user = new UserFromWeb
            {
                hireable = isHireable
            };
            var request = new HttpRequestMessage(HttpMethod.Patch, new Uri("/user", UriKind.Relative));
            request.Headers.Add("Authorization", authToken);
            var content = JsonConvert.SerializeObject(user, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            request.Content = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(request);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }

        private static string GetBasicToken()
        {
            var id = GitHubClientId;
            var secret = GitHubSecret;
            var tokenRaw = $"{id}:{secret}";
            var tokenBytes = Encoding.UTF8.GetBytes(tokenRaw);
            var token = Convert.ToBase64String(tokenBytes);

            return "Basic " + token;
        }
    }
}