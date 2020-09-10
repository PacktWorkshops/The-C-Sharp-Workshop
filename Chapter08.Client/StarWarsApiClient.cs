using Chapter08.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Chapter08
{
    public class StarWarsApiClient
    {
        public enum BackEndOptions
        {
            Local,
            Public
        }

        private readonly HttpClient _client;

        public StarWarsApiClient(BackEndOptions backend)
        {
            var backends = new Dictionary<BackEndOptions, string>()
            {
                [BackEndOptions.Local] = "https://localhost:44341/",
                [BackEndOptions.Public] = "https://swapi.dev/api/"
            };

            BackEnd = backend;

            _client = new HttpClient() { BaseAddress = new Uri(backends[backend]) };
        }

        public BackEndOptions BackEnd { get; }

        public async Task<IEnumerable<Person>> GetAllPeopleAsync() => await GetListInternalAsync<Person>("people/");

        public async Task<IEnumerable<Starship>> GetAllStarshipsAsync() => await GetListInternalAsync<Starship>("starships/");

        private async Task<IEnumerable<T>> GetListInternalAsync<T>(string resource)
        {
            var results = new List<T>();

            var response = await _client.GetFromJsonAsync<Response<List<T>>>(resource);
            results.AddRange(response.Data);

            while (true)
            {
                if (response.Next == null) break;
                response = await _client.GetFromJsonAsync<Response<List<T>>>(response.Next);
                results.AddRange(response.Data);
            }

            return results;
        }

        public async Task<Person> GetPersonAsync(int id) => await _client.GetFromJsonAsync<Person>($"people/{id}/");

        public async Task<Starship> GetStarshipAsync(int id) => await _client.GetFromJsonAsync<Starship>($"starships/{id}/");
    }
}
