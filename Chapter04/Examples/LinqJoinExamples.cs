using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter04.Examples
{
    record Manufacturer(int ManufacturerId, string Name);

    record Car (string Name, int ManufacturerId);

    class LinqJoinExamples
    {

        public static void Main()
        {

            var manufacturers = new List<Manufacturer>
            {
                new(1, "Ford"),
                new(2, "BMW"),
                new(3, "VW")
            };

            var cars = new List<Car>
            {
                new("Focus", 1),
                new("Galaxy", 1),
                new("GT40", 1),
                new("1 Series", 2),
                new("2 Series", 2),
                new("Golf", 3),
                new("Polo", 3)
            };

            var joinedQuery = manufacturers.Join(
                cars,
                manufacturer => manufacturer.ManufacturerId,
                car => car.ManufacturerId,
                (manufacturer, car) => new {ManufacturerName = manufacturer.Name, CarName = car.Name});
            foreach (var item in joinedQuery)
            {
                Console.WriteLine($"{item}");
            }

            var query = from manufacturer in manufacturers
                        join car in cars
                            on manufacturer.ManufacturerId equals car.ManufacturerId
                        select new
                        {
                            ManufacturerName = manufacturer.Name, CarName = car.Name
                        };
            foreach (var item in query)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
