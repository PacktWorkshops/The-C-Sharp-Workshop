using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02.Examples.InheritanceAndPolymorphism.Static
{
    public class Person
    {
        public void Say()
        {
            Console.WriteLine("Hello");
        }

        public void Say(string words)
        {
            Console.WriteLine(words);
        }
    }
}
