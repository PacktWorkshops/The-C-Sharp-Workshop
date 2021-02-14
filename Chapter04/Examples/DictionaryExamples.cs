using System;
using System.Collections.Generic;

namespace Chapter04.Examples
{

    public record Country(string Name)
    {}

    class DictionaryExamples
    {
        public static void Main()
        {
            var countries = new Dictionary<string, Country>
            {
                {"AFG", new Country("Afghanistan")},
                {"ALB", new Country("Albania")},
                {"DZA", new Country("Algeria")},
                {"ASM", new Country("American Samoa")},
                {"AND", new Country("Andorra")}
            };

            Console.WriteLine("Enumerate foreach KeyValuePair");
            foreach (var kvp in countries)
            {
                Console.WriteLine($"\t{kvp.Key} = {kvp.Value.Name}");
            }


            Console.WriteLine("set indexor AFG to new value");
            countries["AFG"] = new Country("AFGHANISTAN");
            Console.WriteLine($"get indexor AFG: {countries["AFG"].Name}");
            
            Console.WriteLine($"ContainsKey {"AGO"}: {countries.ContainsKey("AGO")}");
            Console.WriteLine($"ContainsKey {"and"}: {countries.ContainsKey("and")}"); // Case sensitive

            var anguilla = new Country("Anguilla");
            Console.WriteLine($"Add {anguilla}...");
            countries.Add("AIA", anguilla);
            try
            {
                var anguillaCopy = new Country("Anguilla");
                Console.WriteLine($"Adding {anguillaCopy}...");
                countries.Add("AIA", anguillaCopy);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Caught {e.Message}");
            }

            var addedAIA = countries.TryAdd("AIA", new Country("Anguilla"));
            Console.WriteLine($"TryAdd AIA: {addedAIA}");

            var tryGet = countries.TryGetValue("ALB", out Country albania1);
            Console.WriteLine($"TryGetValue for ALB: {albania1} Result={tryGet}");

            countries.TryGetValue("alb", out Country albania2);
            Console.WriteLine($"TryGetValue for ALB: {albania2}");
        }
    }
}
