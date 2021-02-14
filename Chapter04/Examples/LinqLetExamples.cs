using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter04.Examples
{
    class LinqLetExamples
    {

        public static void Main()
        {
            var stations = new List<string>
            {
                "Kings Cross KGX",
                "Liverpool Street LVS",
                "Euston EUS",
                "New Street NST"
            };

            var query1 = from station in stations
                         where station[^3..] == "LVS" || station[^3..] == "EUS" ||
                               station[0..^3].Trim().ToUpper().EndsWith("CROSS")
                         select new { code = station[^3..], name = station[0..^3].Trim().ToUpper() };

            Console.WriteLine("Station Codes: ");
            foreach (var item in query1)
                Console.WriteLine($"{item.code} : {item.name}");

            var query2 = from station in stations
                         let code = station[^3..]
                         let name = station[0..^3].Trim().ToUpper()
                         where code == "LVS" || code == "EUS" ||
                               name.EndsWith("CROSS")
                         select new { code, name };

            Console.WriteLine("Station Codes (2): ");
            foreach (var item in query2)
                Console.WriteLine($"{item.code} : {item.name}");

        }
    }
}
