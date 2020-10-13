using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter05.Exercise03
{
    public class CarSale
    {
        public CarSale(string name, double salePrice)
        {
            Name = name;
            SalePrice = salePrice;
        }

        public string Name { get; }
        public double SalePrice { get; }
    }

    public interface ISalesLoader
    {
        public IEnumerable<CarSale> FetchSales();
    }

    public static class SalesAggregator
    {
        public static Task<double> Average(IEnumerable<ISalesLoader> loaders)
        {
            var loaderTasks = loaders.Select(ldr => Task.Run(ldr.FetchSales));

            return Task
                .WhenAll(loaderTasks)
                .ContinueWith(tasks =>
                {
                    var average = tasks.Result
                        .SelectMany(t => t)
                        .Average(car => car.SalePrice);

                    return average;
                });
        }
    }

    public class SalesLoader : ISalesLoader
    {
        private readonly Random _random;
        private readonly string _name;

        public SalesLoader(int id, Random rand)
        {
            _name = $"Loader#{id}";
            _random = rand;
        }

        public IEnumerable<CarSale> FetchSales()
        {
            var delay = _random.Next(1, 3);
            Logger.Log($"FetchSales {_name} sleeping for {delay} seconds ...");
            Thread.Sleep(TimeSpan.FromSeconds(delay));

            var sales = Enumerable
                .Range(1, _random.Next(1, 5))
                .Select(n => GetRandomCar())
                .ToList();

            foreach (var car in sales)
                Logger.Log($"FetchSales {_name} found: {car.Name} @ {car.SalePrice:N0}");

            return sales;
        }

        private readonly string[] _carNames = { "Ford", "BMW", "Fiat", "Mercedes", "Porsche" };
        private CarSale GetRandomCar()
        {
            var nameIndex = _random.Next(_carNames.Length);
            return new CarSale(
                _carNames[nameIndex], _random.NextDouble() * 1000);
        }
    }


    public class Program
    {
        public static void Main()
        {
            var random = new Random();

            string input;
            do
            {
                Console.WriteLine("Max wait time (in seconds):");
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    continue;

                if (int.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out var maxDelay))
                {
                    var loaders = Enumerable.Range(1, random.Next(1, 5))
                        .Select(n => new SalesLoader(n, random))
                        .ToList();

                    var averageTask = SalesAggregator.Average(loaders);
                    var hasCompleted = averageTask.Wait(TimeSpan.FromSeconds(maxDelay));
                    var average = averageTask.Result;

                    if (hasCompleted)
                    {
                        Logger.Log($"Average={average:N0}");
                    }
                    else
                    {
                        Logger.Log("Timeout!");
                    }
                }

            } while (input != string.Empty);

            
        }

    }
}
