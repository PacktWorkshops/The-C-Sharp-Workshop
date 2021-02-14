using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter04.Examples
{
    record CustomerOrder(string Name, string Product, int Quantity);

    class LinqGroupByExamples
    {
        public static void Main()
        {
            var orders = new List<CustomerOrder>
            {
                new CustomerOrder("Mr Green", "LED TV", 4),
                new CustomerOrder("Mr Smith", "iPhone", 2),
                new CustomerOrder("Mrs Jones", "Printer", 1),
                new CustomerOrder("Mr Smith", "PC", 5),
                new CustomerOrder("Mr Green", "MP3 Player", 1),
                new CustomerOrder("Mr Green", "Microwave Oven", 1),
                new CustomerOrder("Mr Smith", "Printer", 2),
            };

            foreach (var grouping in orders.GroupBy(o => o.Name))
            {
                Console.WriteLine($"Customer {grouping.Key}:");
                foreach (var item in grouping.OrderByDescending(i => i.Quantity))
                {
                    Console.WriteLine($"\t{item.Product} * {item.Quantity}");
                }
            }

            var query = from order in orders
                        group order by order.Name;
            foreach (var grouping in query)
            {
                Console.WriteLine($"Customer {grouping.Key}:");
                foreach (var item in from item in grouping 
                                     orderby item.Quantity descending 
                                     select item)
                {
                    Console.WriteLine($"\t{item.Product} * {item.Quantity}");
                }
            }

            Console.ReadLine();
        }
    }
}
