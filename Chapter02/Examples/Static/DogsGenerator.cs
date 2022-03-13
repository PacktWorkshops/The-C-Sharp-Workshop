using System;
using Chapter02.Examples.Encapsulation;

namespace Chapter02.Examples.Static
{
    public class DogsGenerator
    {
        public static int Counter { get; private set; }

        static DogsGenerator()
        {
            Counter = 1;
        }

        public static Dog GenerateDog()
        {
            Counter++;
            return new Dog("Dog" +Counter);
        }
    }
}
