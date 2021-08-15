using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Chapter08.Examples.GitHttp
{
    public static class Demo
    {
        public static async Task Run()
        {
            var client = new HttpClient {BaseAddress = new Uri("https://api.github.com")};
            client.DefaultRequestHeaders.Add("User-Agent", "Packt");

            const string username = "almantask";
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri($"users/{username}", UriKind.Relative));
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(content);

            Console.WriteLine($"{user.Name} created profile at {user.CreatedAt}");
        }
    }
}