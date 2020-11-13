using System;
using Chapter02.Examples.Encapsulation;

namespace Chapter02.Examples.Static
{
    public class DataGenerator
    {
        public static int Counter { get; set; } = 0;

        private static readonly Random _random = new Random();
        private static readonly string[] _namesPool = {"Ricky", "Speedy"};

        public static Dog GenerateDog()
        {
            var nameIndex = _random.Next();
            var name = _namesPool[nameIndex];
            Counter++;

            return new Dog(name);
        }
    }
}
