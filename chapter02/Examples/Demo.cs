using System;
using Chapter02.Examples.Professions;

namespace Chapter02.Examples
{
    public class Demo
    {
        public static void Run()
        {
            DemoEncapsulation();
            DemoInheritance();
            DemoPolymorphism();
        }

        private static void DemoEncapsulation()
        {
            var sparky = new Dog("Sparky");
            var ricky = new Dog("Ricky");
            sparky.Bark();
            ricky.Sit();
        }

        private static void DemoInheritance()
        {
            var mailman = new Mailman("Thomas", 29, 78.5f, 190.11f);
            var mail = new Mail("Hello", "Somewhere far far way");
            mailman.SendMail(mail);
        }

        private static void DemoPolymorphism()
        {
            Mailman mailman = new Mailman("Thomas", 29, 78.5f, 190.11f);
            Teacher teacher = new Teacher("Gareth", 35, 100.5f, 186.49f);
            // Specialized types can be stored as their generalized forms.
            Human[] humans = {mailman, teacher};
            foreach (var human in humans)
            {
                human.Work();
            }
            foreach (var human in humans)
            {
                Console.WriteLine(human);
            }
        }
    }
}