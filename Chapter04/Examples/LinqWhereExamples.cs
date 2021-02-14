using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter04.Examples
{

    record Order (string Product, int Quantity, double Price);

    class LinqWhereExamples
    {
        public static void Main()
        {
            var orders = new List<Order>
            {
                new Order("Pen", 2, 1.99),
                new Order("Pencil", 5, 1.50),
                new Order("Note Pad", 1, 2.99),
                new Order("Stapler", 1, 3.99),
                new Order("Ruler", 10, 0.5),
                new Order("USB Memory Stick", 6, 20)
            };

            Console.WriteLine("Orders with quantity over 5:");
            foreach (var order in orders.Where(o => o.Quantity > 5))
            {
                Console.WriteLine(order);
            }

            Console.WriteLine("Pens or Pencils:");
            foreach (var orderValue in orders
                .Where(o => o.Product == "Pen"  || o.Product == "Pencil")
                .Select( o => o.Quantity * o.Price))
            {
                Console.WriteLine(orderValue);
            }

            var query = from order in orders
                where order.Price <= 3.99
                select new {Name = order.Product, Value = order.Quantity * order.Price};
            Console.WriteLine("Cheapest Orders:");
            foreach(var order in query)
            {
                Console.WriteLine($"{order.Name}: {order.Value}");
            }

        }
    }
}
