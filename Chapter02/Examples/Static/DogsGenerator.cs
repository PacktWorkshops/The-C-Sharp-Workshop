using System;
using Chapter02.Examples.Encapsulation;

namespace Chapter02.Examples.Static
{
    public class DogsGenerator
    {
        public static int Counter { get; private set; }

        static DogsGenerator()
        {
            // Counter will be 0 anyways if not explicitly provided,
            // this just illustrates the use of a static constructor.
            Counter = 0;
        }

        public static Dog GenerateDog()
        {
            Counter++;
            return new Dog("Dog" + Counter);
        }
    }
}
