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
            var results = await api.GetAllPlanetsAsync();
            foreach (var p in results) Console.WriteLine(p.name);
        }
    }
}
