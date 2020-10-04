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

    public class StarWarsApiClient
    {
        private static HttpClient _client = new HttpClient();

        public StarWarsApiClient(HostOptions host)
        {            
            Host = host;            
        }

        public HostOptions Host { get; }

        private string GetFullUrl(string resourceName)
        {
            var hosts = new Dictionary<HostOptions, string>()
            {
                [HostOptions.Local] = "https://localhost:44341/api/",
                [HostOptions.Online] = "https://swapi.dev/api/"
            };

            return hosts[Host] + resourceName;
        }

        public async Task<IEnumerable<Person>> GetAllPeopleAsync() => await GetListInternalAsync<Person>("people/");

        public async Task<IEnumerable<Starship>> GetAllStarshipsAsync() => await GetListInternalAsync<Starship>("starships/");

        private async Task<IEnumerable<T>> GetListInternalAsync<T>(string resource)
        {
            var results = new List<T>();

            var response = await _client.GetFromJsonAsync<Response<List<T>>>(GetFullUrl(resource));
            results.AddRange(response.Data);

            while (true)
            {
                if (response.Next == null) break;
                response = await _client.GetFromJsonAsync<Response<List<T>>>(response.Next);
                results.AddRange(response.Data);
            }

            return results;
        }

        public async Task<Person> GetPersonAsync(int id) => await _client.GetFromJsonAsync<Person>(GetFullUrl($"people/{id}/"));

        public async Task<Starship> GetStarshipAsync(int id) => await _client.GetFromJsonAsync<Starship>(GetFullUrl($"starships/{id}/"));

        public async Task CreatePerson(Person person) => await _client.PostAsJsonAsync(GetFullUrl("people/"), person);
    }
}
