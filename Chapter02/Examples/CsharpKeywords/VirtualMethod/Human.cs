using System;

namespace Chapter02.Examples.CsharpKeywords.VirtualMethod
{
    public class Human
    {
        public string Name { get; }

        public Human(string name)
        {
            Name = name;
        }

        public virtual void SayHi()
        {
            Console.WriteLine("Hello!");
        }
    }
}
