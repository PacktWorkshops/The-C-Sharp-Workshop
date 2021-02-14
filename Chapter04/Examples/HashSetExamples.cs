using System;
using System.Collections.Generic;

namespace Chapter04.Examples
{
    class HashSetExamples
    {
        public static void Main()
        {
            var actors = new List<string> {"Harrison Ford", "Will Smith", "Sigourney Weaver"};
            var singers = new List<string> {"Will Smith", "Adele" };

            var actingOrSinging = new HashSet<string>(singers);
            actingOrSinging.UnionWith(actors);
            Console.WriteLine($"Acting or Singing: {string.Join(", ", actingOrSinging)}");

            var actingAndSinging = new HashSet<string>(singers);
            actingAndSinging.IntersectWith(actors);
            Console.WriteLine($"Acting and Singing: {string.Join(", ", actingAndSinging)}");

            var actingOnly = new HashSet<string>(actors);
            actingOnly.ExceptWith(singers);
            Console.WriteLine($"Acting Only: {string.Join(", ", actingOnly)}");

            Console.ReadLine();
        }
    }
}
