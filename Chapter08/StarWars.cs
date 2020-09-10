using Chapter08.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Chapter08
{
    public static class StarWars
    {
        private static HttpClient Client = new HttpClient() { BaseAddress = new Uri("https://swapi.dev/api/") };

        public static async Task<IEnumerable<Person>> GetAllPeopleAsync() => await GetListInternalAsync<Person>("people/");

        public static async Task<IEnumerable<Starship>> GetAllStarshipsAsync() => await GetListInternalAsync<Starship>("starships/");

        private static async Task<IEnumerable<T>> GetListInternalAsync<T>(string resource)
        {
            var results = new List<T>();

            var response = await Client.GetFromJsonAsync<Response<List<T>>>(resource);
            results.AddRange(response.Data);

            while (true)
            {
                if (response.Next == null) break;
                response = await Client.GetFromJsonAsync<Response<List<T>>>(response.Next);
                results.AddRange(response.Data);
            }

            return results;
        }

        public static async Task<Person> GetPersonAsync(int id) => await Client.GetFromJsonAsync<Person>($"people/{id}/");

        public static async Task<Starship> GetStarshipAsync(int id) => await Client.GetFromJsonAsync<Starship>($"starships/{id}/");
    }
}
