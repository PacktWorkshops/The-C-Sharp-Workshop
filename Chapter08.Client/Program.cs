using Chapter08.Client.Interfaces;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Chapter08
{
    class Program
    {
        static HttpClient Client = new HttpClient() 
        { 
            BaseAddress = new Uri("http://worldtimeapi.org/api/") 
        };

        static async Task Main(string[] args)
        {
            //var response = await Client.GetFromJsonAsync<DateTimeResponse>("ip");

            /*var client = new WorldTimeClient(Client);
            var response = await client.GetCurrentDateTime();
            */

            /*
            var api = RestService.For<IWorldTimeApi>("http://worldtimeapi.org/api/");
            var response = await api.GetCurrentTime();
            Console.WriteLine($"The current date/time is {response.datetime}");
            */

            var api = RestService.For<IStarWarsApi>("https://swapi.dev/api/");
            //var response = await api.GetPeopleAsync();
            //var response = await api.GetPlanetsAsync();

            //var response = await api.GetPersonAsync(3);
            //var response = await api.GetFilmsAsync();
            //var response = await api.GetFilmAsync(1);
            var response = await api.GetPlanetsAsync();
        }
    }
}
