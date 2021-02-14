using System;
using System.Collections.Generic;

namespace Chapter04.Examples
{
    class QueueExamples
    {
        
        record CustomerOrder (string Name, int TicketsRequested)
        {}

        public static void Main()
        {
            var ticketsAvailable = 10;
            var customers = new Queue<CustomerOrder>();
            customers.Enqueue(new CustomerOrder("Dave", 2));
            customers.Enqueue(new CustomerOrder("Siva", 4));
            customers.Enqueue(new CustomerOrder("Julien", 3));
            customers.Enqueue(new CustomerOrder("Kane", 2));
            customers.Enqueue(new CustomerOrder("Ann", 1));

            // Start processing orders...
            while(customers.TryDequeue(out CustomerOrder nextOrder))
            {
                if (nextOrder.TicketsRequested <= ticketsAvailable)
                {
                    ticketsAvailable -= nextOrder.TicketsRequested;   
                    Console.WriteLine($"Congratulations {nextOrder.Name}, you've purchased {nextOrder.TicketsRequested} ticket(s)");
                }
                else
                {
                    Console.WriteLine($"Sorry {nextOrder.Name}, cannot fulfil {nextOrder.TicketsRequested} ticket(s)");
                }
            }
            Console.WriteLine($"Finished. Available={ticketsAvailable}");
            Console.ReadLine();
        }
    }
}