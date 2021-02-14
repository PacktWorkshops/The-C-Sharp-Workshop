using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter04.Examples
{

    record TravelLog (string Name, int Distance, int Duration)
    {
        public double AverageSpeed()
        {
            Console.WriteLine($"AverageSpeed() called for '{Name}'");
            return Distance / Duration;
        }
    }

    class LinqMultipleEnumerationExample
    {

        public static void Main()
        {
            var travelLogs = new List<TravelLog>
            {
                new TravelLog("London to Brighton", 50, 4),
                new TravelLog("Newcastle to London", 300, 24),
                new TravelLog("New York to Florida", 1146, 19),
                new TravelLog("Paris to Berlin", 546, 10)
            };

            var fastestJourneys = travelLogs.Where(tl => tl.AverageSpeed() > 50);
            Console.WriteLine("Fastest Distances:");
            foreach (var item in fastestJourneys)
            {
                Console.WriteLine($"{item.Name}: {item.Distance} miles");
            }
            Console.WriteLine();

            Console.WriteLine("Fastest Duration:");
            foreach (var item in fastestJourneys)
            {
                Console.WriteLine($"{item.Name}: {item.Duration} hours");
            }
            Console.WriteLine();

            Console.WriteLine("Fastest Duration Multiple loops:");
            var fastestJourneysList = travelLogs
                .Where(tl => tl.AverageSpeed() > 50)
                .ToList();
            for (var i = 0; i < 2; i++)
            {
                Console.WriteLine($"Fastest Duration Multiple loop iteration {i+1}:");
                foreach (var item in fastestJourneysList)
                {
                    Console.WriteLine($"{item.Name}: {item.Distance} in {item.Duration} hours");
                }
            }
        }
    }
}
