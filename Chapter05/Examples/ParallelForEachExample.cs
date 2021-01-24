using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter05.Examples
{
    public class Order
    {
        public Order(string product, double value)
        {
            Product = product;
            Value = value;
        }

        public string Product { get; }
        public double Value { get; }
    }

    public class Customer
    {
        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public IList<Order> Orders { get; set; }
        public double? Total { get; set; }
        public double? Average { get; set; }
    }

    public static class Aggregator
    {
public static Task<ParallelLoopResult> Aggregate(IEnumerable<Customer> customers, CancellationToken token)
{
    var calcTask = Task.Run(() =>
    {
        var options = new ParallelOptions { CancellationToken = token };
        var loopResult = Parallel.ForEach(customers, options,
            customer =>
            {
                Logger.Log($"Processing {customer.Name}...");
                customer.Total = customer.Orders.Sum(order => order.Value);
                customer.Average = customer.Total / customer.Orders.Count;
                Thread.Sleep(3000);// simulate delay
                Logger.Log($"Done {customer.Name}...");
            });

        return loopResult;
    });

    return calcTask;
}
    }

    class ParallelForEachExampleProgram
    {
        public static async Task Main()
        {
            Console.Write("Max waiting time:");
            var input = Console.ReadLine();
            var maxWait = TimeSpan.FromSeconds(int.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out var intResult) 
                ? intResult 
                : 5000);

            var customers = new[] {"Max", "Monty", "Heidi", "Bella", "Percy"}
                .Select(name => new Customer(name))
                .ToList();

            var random = new Random();
            var populateCustomerTask = customers.Select(cust => 
            {
                return Task.Run(() =>
                {
                    var orderCount = random.Next(1000, 10000);
                    Logger.Log($"Customer {cust.Name} creating {orderCount:N0} orders...");
                    cust.Orders = Enumerable
                        .Range(1, orderCount)
                        .Select(n => new Order($"Item{n}", random.NextDouble() * 1000D))
                        .ToList();
                });
            });

            await Task.WhenAll(populateCustomerTask);

            var tokenSource = new CancellationTokenSource(maxWait);
            var aggregateTask = Task.Run(() => Aggregator.Aggregate(customers, tokenSource.Token));

            var result = await aggregateTask;
            Console.WriteLine($"Completed: {result.IsCompleted}");
            Console.WriteLine("Customer      \tTotal         \tAverage");
            foreach (var c in customers)
            {
                Console.WriteLine($"{c.Name.PadLeft(10)}\t{c.Total:N0}\t{c.Average:N0}");
            }

            Console.ReadLine();

        }
    }
}
