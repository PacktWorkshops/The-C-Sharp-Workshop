using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter06.Exercises.Exercise03
{
    public static class Demo
    {
        public static void Run()
        {
            var db = new AdventureWorksContext();
            var locations = db.Locations.ToList();

            foreach (var location in locations)
            {
                Console.WriteLine($"{location.LocationId} {location.Name} {location.Costrate} {location.Availability} {location.ModifiedDate}");
            }

            db.Dispose();
        }
    }
}
