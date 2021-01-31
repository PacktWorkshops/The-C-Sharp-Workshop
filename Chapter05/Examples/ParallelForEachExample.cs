using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter05.Examples
{
    public class Customer
    {
        public Customer(string name)
        {
            Name = name;
            Logger.Log($"Created {Name}");
        }

        public string Name { get; }

        private readonly object _orderGate = new object();
        private IList<double> _orders;
        public IList<double> Orders
        {
            get
            {
                lock (_orderGate)
                {
                    if (_orders != null)
                        return _orders;

                    var random = new Random();
                    var orderCount = random.Next(1000, 10000);

                    _orders = Enumerable
                        .Range(1, orderCount)
                        .Select(n => n * random.NextDouble())
                        .ToList();

                    Thread.Sleep(3000); // simulate delay
                    return _orders;
                }
            }
        }

        public double? Total { get; set; }
        public double? Average { get; set; }
    }

    public static class Aggregator
    {
        public static Task<bool> Aggregate(IEnumerable<Customer> customers, CancellationToken token)
        {
            var wasCancelled = false;

            return Task.Run(() =>
            {
                var options = new ParallelOptions { CancellationToken = token };

                try
                {
                    Parallel.ForEach(customers, options,
                        customer =>
                        {
                            customer.Total = customer.Orders.Sum();
                            customer.Average = customer.Total / customer.Orders.Count;
                            Logger.Log($"Processed {customer.Name}");
                        });
                }
                catch (OperationCanceledException ex)
                {
                    Logger.Log($"Caught {ex.Message}");
                    wasCancelled = true;
                }
                return wasCancelled;
            });
        }
    }

    class ParallelForEachExampleProgram
    {
        public static async Task Main()
        {
            Console.Write("Max waiting time (seconds):");
            var input = Console.ReadLine();
            var maxWait = TimeSpan.FromSeconds(int.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out var inputSeconds)
                ? inputSeconds
                : 5);

            var customers = Enumerable.Range(1, 10)
                .Select(n => new Customer($"Customer#{n}"))
                .ToList();

            var tokenSource = new CancellationTokenSource(maxWait);
            var aggregated = await Task.Run(() => Aggregator.Aggregate(customers, tokenSource.Token));

            var topCustomers = customers
                .OrderByDescending(c => c.Total)
                .Take(5);

            Console.WriteLine($"Cancelled: {aggregated }");
            Console.WriteLine("Customer      \tTotal         \tAverage  \tOrders");
            foreach (var c in topCustomers)
            {
                Console.WriteLine($"{c.Name.PadRight(10)}\t{c.Total:N0}\t{c.Average:N0}\t\t{c.Orders.Count:N0}");
            }

            Console.ReadLine();

        }
    }
}
