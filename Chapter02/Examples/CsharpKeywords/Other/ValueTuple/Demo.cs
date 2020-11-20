using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter02.Examples.Abstraction.Players;
using Chapter02.Examples.Encapsulation;

namespace Chapter02.Examples.CsharpKeywords.Other.ValueTuple
{
    public static class Demo
    {
        public static void Run()
        {
            var dog = new Dog("?");
            var human = new Human("Thomas");
            bool isDogKnown = false;

            var values1 = new ValueTuple<Dog, Human, bool>(dog, human, isDogKnown);
            var values2 = (dog, human, isDogKnown);

            var (d, h, b) = GetDogHumanAndBool();
        }

        public static (Dog, Human, bool) GetDogHumanAndBool()
        {
            var dog = new Dog("?");
            var human = new Human("Thomas");
            bool isDogKnown = false;

            return (dog, human, isDogKnown);
        }
    }
}
