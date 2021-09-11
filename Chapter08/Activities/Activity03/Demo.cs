using System;
using System.Collections.Generic;
using System.Linq;
using Chapter08.Activities.Activity02;
using Refit;

namespace Chapter08.Activities.Activity03
{
    public static class Demo
    {
        public static void Run()
        {
            var client = RestService.For<ICountriesClient>("https://restcountries.com/v3/");
            
            Console.WriteLine("All:");
            Print(client.Get().Result);

            Console.WriteLine($"{Environment.NewLine}Lithuanian:");
            Print(client.GetByLanguage("Lithuanian").Result);

            Console.WriteLine($"{Environment.NewLine}Vilnius:");
            Print(client.GetByCapital("Vilnius").Result);
        }

        private static void Print(IEnumerable<Country> countries)
        {
            foreach (var country in countries.Take(2))
            {
                Console.WriteLine($"{country.name.common} {country.region} {string.Join(" ", country.capital ?? new List<string>())}");
            }
        }
    }
}
