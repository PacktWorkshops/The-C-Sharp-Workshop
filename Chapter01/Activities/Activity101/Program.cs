using System;

namespace Activity101
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please type your name:");
            var name = Console.ReadLine();
            
            Console.WriteLine("\nPlease type your contry of residence:");
            var countryOfResidence = Console.ReadLine();

            Console.WriteLine("\nPlease type your age:");
            var age = Console.ReadLine();

            Console.WriteLine($"Hello {name}, from {countryOfResidence}. You’re still very young at {age} and has a lot of programming to do in life. Count on me!");
        }
    }
}
