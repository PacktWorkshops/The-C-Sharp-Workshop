using System;

namespace Chapter02.Examples
{
    public class Dog
    {
        public string Name {get;}

        public Dog(string name)
        {
            Name = name;
        }

        public void Sit()
        {
            System.Console.WriteLine(Name + " is sitting");
        }

        public void Bark()
        {
            System.Console.WriteLine("Woof woof");
        }
    }
}