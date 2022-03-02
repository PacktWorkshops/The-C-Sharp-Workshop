using System;
using System.Collections.Generic;

namespace Chapter03Examples
{
    class LambdaExample
    {
        public static void Main()
        {
            var names = new List<string>
            {
                "The A-Team",
                "Blade Runner",
                "There's Something About Mary",
                "Batman Begins",
                "The Crow"
            };

            names.Sort();
            Console.WriteLine("Sorted names:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();


            const string Noise = "The ";
            names.Sort( (x, y) =>
            {
                if (x.StartsWith(Noise))
                {
                    x = x.Substring(Noise.Length);
                }

                if (y.StartsWith(Noise))
                {
                    y = x.Substring(Noise.Length);
                }

                return string.Compare(x , y);
            });
            Console.WriteLine($"Sorted excluding leading '{Noise}':");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.ReadLine();
         }
     }
}

