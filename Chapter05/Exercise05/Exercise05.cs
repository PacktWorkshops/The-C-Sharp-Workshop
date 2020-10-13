using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examples.Chapter05;

namespace Chapter05.Exercise05
{
    public class Customer
    {
        private readonly RegionName _protectedRegion;

        public Customer(string name, RegionName region, RegionName protectedRegion)
        {
            Name = name;
            Region = region;
            _protectedRegion = protectedRegion;
        }

        public string Name { get; }
        public RegionName Region { get; }

        private int _totalOrders;
        public int TotalOrders
        {
            get
            {
                if (Region == _protectedRegion)
                {
                    throw new AccessViolationException($"Cannot access orders for {Name}");
                }

                return _totalOrders;
            }
            set => _totalOrders = value;
        }
    }

    public class CustomerOperations
    {
        public const RegionName ProtectedRegion = RegionName.West;

        public async Task<IEnumerable<Customer>> FetchTopCustomers()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));

            Logger.Log("Loading customers...");
            var customers = new List<Customer>
            {
                new Customer("Rick Deckard", RegionName.North, ProtectedRegion),
                new Customer("Taffey Lewis", RegionName.North, ProtectedRegion),
                new Customer("Rachael", RegionName.North, ProtectedRegion),
                new Customer("Roy Batty", RegionName.West, ProtectedRegion),
                new Customer("Eldon Tyrell", RegionName.East, ProtectedRegion)
            };

            await FetchOrders(customers);

            var filteredCustomers = new List<Customer>();
            foreach (var customer in customers)
            {
                try
                {
                    if (customer.TotalOrders > 0)
                        filteredCustomers.Add(customer);
                }
                catch (AccessViolationException e)
                {
                    Logger.Log($"Error {e.Message}");
                }
            }

            return filteredCustomers.OrderByDescending(c => c.TotalOrders);
        }

        private async Task FetchOrders(IEnumerable<Customer> customers)
        {
            var rand = new Random();

            Logger.Log("Loading orders...");
            var orderUpdateTasks = customers.Select(
              cust => Task.Run(async () =>
              {
                    await Task.Delay(500);
                    cust.TotalOrders = rand.Next(1, 100);
               }))
              .ToList();

            await Task.WhenAll(orderUpdateTasks);
        }
    }

    public class Program
    {
        public static async Task Main()
        {
            var ops = new CustomerOperations();
            var resultTask = ops.FetchTopCustomers();

            var customers = await resultTask;

            foreach (var customer in customers)
            {
                Logger.Log($"{customer.Name} ({customer.Region}): {customer.TotalOrders:N0}");
            }
            Console.ReadLine();
        }

    }

}
