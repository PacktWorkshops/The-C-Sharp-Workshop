using Chapter08.Client.Interfaces;
using Refit;
using System;
using System.Threading.Tasks;

namespace Chapter08
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var api = RestService.For<IStarWarsApi>("https://swapi.dev/api/");
            var response = await api.GetPlanetsAsync();
            foreach (var p in response.results)
            {
                Console.WriteLine(p.name);
            }
        }
    }
}
