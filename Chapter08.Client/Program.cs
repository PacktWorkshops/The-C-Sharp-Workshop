using Refit;
using System;
using Chapter08.Client.Interfaces;
using Chapter08.Client.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter08
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var api = RestService.For<IStarWarsApi>("https://swapi.dev/api/");
            var page1 = await api.GetPlanetsAsync(1);
            ListPlanets(1, page1.results);

            var page2 = await api.GetPlanetsAsync(2);
            ListPlanets(2, page2.results);

            void ListPlanets(int page, IEnumerable<Planet> planets)
            {
                Console.WriteLine($"page {page}:");
                planets.ToList().ForEach(p => Console.WriteLine($"- {p.name}"));
                Console.WriteLine();
            }
        }
    }
}
