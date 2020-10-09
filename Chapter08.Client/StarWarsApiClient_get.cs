using Chapter08.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
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

        public async Task<Person> GetPersonAsync(int id) => await _client.GetFromJsonAsync<Person>(BuildUrl($"people/{id}/"));

        public async Task<Film> GetFilmAsync(int id) => await _client.GetFromJsonAsync<Film>(BuildUrl($"films/{id}/"));

        public async Task<T> GetAsync<T>(string resource) => await _client.GetFromJsonAsync<T>(BuildUrl(resource));

        public async Task<Starship> GetStarshipAsync(int id) => await _client.GetFromJsonAsync<Starship>(BuildUrl($"starships/{id}/"));

        public async Task<IEnumerable<Person>> GetAllPeopleAsync() => await GetListInternalAsync<Person>("people/");

        public async Task<IEnumerable<Starship>> GetAllStarshipsAsync() => await GetListInternalAsync<Starship>("starships/");

        private async Task<IEnumerable<T>> GetListInternalAsync<T>(string resource)
        {
            var results = new List<T>();

            var response = await _client.GetFromJsonAsync<ApiResult<List<T>>>(BuildUrl(resource));
            results.AddRange(response.Data);

            while (true)
            {
                if (response.Next == null) break;
                response = await _client.GetFromJsonAsync<ApiResult<List<T>>>(response.Next);
                results.AddRange(response.Data);
            }

            return results;
        }
    }
}
