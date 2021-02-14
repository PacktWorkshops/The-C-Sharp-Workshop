using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter04.Examples
{
 
    class LinqSelectExamples
    {
        public static void Main()
        {
            var days = new List<string> { "Mon", "Tues", "Wednes"};

            var query1 = days.Select(d => d + "day");
            foreach(var day in query1)
                Console.WriteLine($"Query1: {day}");

            var query2 = days.Select((d, i) => $"{i} : {d}day");
            foreach (var day in query2)
                Console.WriteLine($"Query2: {day}");

            var query3 = days.Select((d, i) => new
            {
                Index = i, 
                UpperCaseName = $"{d.ToUpper()}DAY"
            });
            foreach (var day in query3)
                Console.WriteLine($"Query3: Index={day.Index}, UpperCaseDay={day.UpperCaseName}");

            var query4 = from day in days
                         select day + "day";
            foreach (var day in query4)
                Console.WriteLine($"Query4: {day}");

            var query5 = from dayIndex in days.Select((d, i) => new {Name = d, Index = i})
                         select dayIndex;
            foreach (var day in query5)
                Console.WriteLine($"Query5: Index={day.Index} : {day.Name}");

            Console.ReadLine();
        }
    }
}
