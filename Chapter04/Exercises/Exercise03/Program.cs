using System;
using System.Linq;

namespace Chapter04.Exercises.Exercise03
{
    class Program
    {
        record Country (string Name, string Continent, int Area);


        public static void Main()
        {
            var countries = new[]
            {
                new Country("Seychelles", "Africa", 176),
                new Country("India", "Asia", 1_269_219),
                new Country("Brazil", "South America",3_287_956),
                new Country("Argentina", "South America", 1_073_500),
                new Country("Mexico", "South America",750_561),
                new Country("Peru", "South America",494_209),
                new Country("Algeria", "Africa", 919_595),
                new Country("Sudan", "Africa", 668_602)
            };

            var requiredContinents = new[] {"South America", "Africa"};

            var filteredCountries = countries
                .Where(c => requiredContinents.Contains(c.Continent))
                .OrderBy(c => c.Continent)
                .ThenByDescending(c => c.Area)
                .Select( (cty, i) => new {Index = i, Country = cty});
                

            foreach(var item in filteredCountries)
                Console.WriteLine($"{item.Index+1}: {item.Country.Continent}, {item.Country.Name} = {item.Country.Area:N0} sq mi");
        }
    }
}
