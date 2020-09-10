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

        public static async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            var results = new List<Person>();

            var response = await Client.GetFromJsonAsync<Response<List<Person>>>("people/");
            results.AddRange(response.Data);

            while (true)
            {
                if (response.Next == null) break;
                response = await Client.GetFromJsonAsync<Response<List<Person>>>(response.Next);
                results.AddRange(response.Data);
            }

            return results;
        }

        public static async Task<Person> GetPersonAsync(int id) => await Client.GetFromJsonAsync<Person>($"people/{id}/");
    }
}
