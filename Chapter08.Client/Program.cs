using Chapter08.Models;
using RestSharp;
using RestSharp.Serializers.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chapter08
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /*var api = RestService.For<IStarWarsApi>("https://swapi.dev/api/");
            var results = await api.GetAllPlanetsAsync();
            foreach (var p in results) Console.WriteLine(p.Name);*/

            /*var client = new RestClient("https://swapi.dev/api/");
            client.UseSystemTextJson();
            var request = new RestRequest("starships/");
            var response = await client.GetAsync<ApiResult<List<Starship>>>(request);*/

            var client = new StarWarsApiClient(HostOptions.Online);
            var person = await client.GetPersonAsync(10);
            Console.WriteLine(person.Name);
            foreach (var f in person.Films)
            {
                var film = await client.GetAsync<Film>(f);
                Console.WriteLine($"- {film.Title}");
            }
        }
    }
}
