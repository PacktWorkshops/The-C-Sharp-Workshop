using System;
using Chapter02.Examples.InheritanceAndPolymorphism;

namespace Chapter02.Examples.Abstraction.Workers
{
    public class Mailman : Human
    {
        public Mailman(string name, int age, float weight, float height) : base(name, age, weight, height)
        {
        }

        public void DeliverMail(Mail mail)
        {
            // Delivering Mail...
        }

        public override void Work()
        {
            Console.WriteLine("Mailman is working...");
        }
    }
}