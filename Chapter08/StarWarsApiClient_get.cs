using Chapter08.Extensions;
using Chapter08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Chapter08
{
    public enum HostOptions
    {
        Local,
        Online
    }

    /// <summary>
    /// this partial class defines the http get methods for our client
    /// </summary>
    public partial class StarWarsApiClient
    {
        private static HttpClient _client = new HttpClient();

        public StarWarsApiClient(HostOptions host)
        {
            Host = host;
        }

        public HostOptions Host { get; }

        /// <summary>
        /// For relative resources, this prepends the current Host name in effect.
        /// For absolute resources, this returns the original resource unchanged.
        /// </summary>
        private string BuildUrl(string resourceName)
        {
            if (isAbsolute(resourceName)) return resourceName;

            var hosts = new Dictionary<HostOptions, string>()
            {
                [HostOptions.Local] = "https://localhost:44341/api/",
                [HostOptions.Online] = "https://swapi.dev/api/"
            };

            return hosts[Host] + resourceName;

            bool isAbsolute(string url)
            {
                try
                {
                    return new Uri(url).IsAbsoluteUri;
                }
                catch 
                {
                    return false;
                }
            }
        }

        public async Task<Person> GetPersonAsync(int id) => await _client.GetFromJsonAsync<Person>(BuildUrl($"people/{id}/"), GetOptions());

        public async Task<Film> GetFilmAsync(int id) => await _client.GetFromJsonAsync<Film>(BuildUrl($"films/{id}/"), GetOptions());

        public async Task<T> GetAsync<T>(string resource) => await _client.GetFromJsonAsync<T>(BuildUrl(resource), GetOptions());

        public async Task<Starship> GetStarshipAsync(int id) => await _client.GetFromJsonAsync<Starship>(BuildUrl($"starships/{id}/"), GetOptions());

        public async Task<IEnumerable<Person>> GetAllPeopleAsync() => await GetListInternalAsync<Person>("people/");

        public async Task<IEnumerable<Starship>> GetAllStarshipsAsync() => await GetListInternalAsync<Starship>("starships/");

        private async Task<IEnumerable<T>> GetListInternalAsync<T>(string resource)
        {
            var results = new List<T>();

            var response = await _client.GetFromJsonAsync<ApiResult<List<T>>>(BuildUrl(resource), GetOptions());
            results.AddRange(response.Data);

            while (true)
            {
                if (response.Next == null) break;
                response = await _client.GetFromJsonAsync<ApiResult<List<T>>>(response.Next, GetOptions());
                results.AddRange(response.Data);
            }

            return results;
        }

        private JsonSerializerOptions GetOptions() => new JsonSerializerOptions()
        {
            PropertyNamingPolicy = new StarWarsNamingPolicy()
        };
    }

    public class StarWarsNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => UnderscoreWords(name);

        /// <summary>
        /// SWAPI property names are lower case with underscores between words, so
        /// we use this to convert Pascal-named properties to this format
        /// </summary>
        private string UnderscoreWords(string input)
        {
            var words = input.SplitWhere((c, position) => char.IsUpper(c) && position > 0);
            return string.Join("_", words.Select(w => w.ToLower()));            
        }
    }
}
