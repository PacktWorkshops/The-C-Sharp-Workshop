using System;

namespace Chapter02.Examples.InheritanceAndPolymorphism
{
    public class Mailman : Human
    {
        public Mailman(string name, int age, float weight, float height) : base(name, age, weight, height)
        {
        }

        public void SendMail(Mail mail)
        {
            // Sending Mail...
        }

        public override void Work()
        {
            Console.WriteLine("A mailman is sending mails.");
        }
    }
}