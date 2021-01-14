using System;

namespace Chapter02.Examples.Abstraction.Workers
{
    public class Teacher : Human
    {
        public Teacher(string name, int age, float weight, float height) : base(name, age, weight, height)
        {
        }

        public override void Work()
        {
            Console.WriteLine("Teaching");
        }
    }
}