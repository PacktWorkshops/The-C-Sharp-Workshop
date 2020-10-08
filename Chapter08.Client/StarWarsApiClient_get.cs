using Chapter08.Models;
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

        private string GetUrl(string resourceName)
        {
            var hosts = new Dictionary<HostOptions, string>()
            {
                [HostOptions.Local] = "https://localhost:44341/api/",
                [HostOptions.Online] = "https://swapi.dev/api/"
            };

            return hosts[Host] + resourceName;
        }

        public async Task<Person> GetPersonAsync(int id) => await _client.GetFromJsonAsync<Person>(GetUrl($"people/{id}/"));

        public async Task<Film> GetFilmAsync(int id) => await _client.GetFromJsonAsync<Film>(GetUrl($"films/{id}/"));

        public async Task<T> GetAsync<T>(string resource, bool absolute = false) => await _client.GetFromJsonAsync<T>((absolute) ? resource : GetUrl(resource));

        public async Task<Starship> GetStarshipAsync(int id) => await _client.GetFromJsonAsync<Starship>(GetUrl($"starships/{id}/"));

        public async Task<IEnumerable<Person>> GetAllPeopleAsync() => await GetListInternalAsync<Person>("people/");

        public async Task<IEnumerable<Starship>> GetAllStarshipsAsync() => await GetListInternalAsync<Starship>("starships/");

        private async Task<IEnumerable<T>> GetListInternalAsync<T>(string resource)
        {
            var results = new List<T>();

            var response = await _client.GetFromJsonAsync<ApiResult<List<T>>>(GetUrl(resource));
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
