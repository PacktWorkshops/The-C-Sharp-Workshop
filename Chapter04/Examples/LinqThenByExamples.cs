using System;
using System.IO;
using System.Linq;

namespace Chapter04.Examples
{

    class LinqThenByExamples
    {
        public static void Main()
        {
            
            var quotes = new[]
            {
                "Love for all hatred for none",
                "Change the world by being yourself",
                "Every moment is a fresh beginning",
                "Never regret anything that made you smile",
                "Die with memories not dreams",
                "Aspire to inspire before we expire"
            };

            foreach (var item in quotes
                .Select(q => new {Quote = q, Words = q.Split(" ").Length})
                .OrderByDescending(q => q.Words)
                .ThenBy(q => q.Quote))
            {
                Console.WriteLine($"{item.Words}: {item.Quote}");
            }

            var query = from quote in (quotes.Select(q => new {Quote = q, Words = q.Split(" ").Length}))
                orderby quote.Words descending, quote.Words ascending 
                select quote;
            foreach(var item in query)        
            {
                Console.WriteLine($"{item.Words}: {item.Quote}");
            }

            Console.ReadLine();
        }
    }
}
