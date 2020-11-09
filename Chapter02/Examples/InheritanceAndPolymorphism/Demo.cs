using System;

namespace Chapter02.Examples.InheritanceAndPolymorphism
{
    public static class Demo
    {
        public static void Run()
        {
            DemoInheritance();
            DemoNoPolymorphism();
            DemoPolymorphism();
        }

        private static void DemoInheritance()
        {
            var mailman = new Mailman("Thomas", 29, 78.5f, 190.11f);
            var mail = new Mail("Hello", "Somewhere far far way");
            mailman.SendMail(mail);
        }

        private static void DemoNoPolymorphism()
        {
            Mailman mailman = new Mailman("Thomas", 29, 78.5f, 190.11f);
            Teacher teacher = new Teacher("Gareth", 35, 100.5f, 186.49f);
            Human[] humans = { mailman, teacher };
            foreach (var human in humans)
            {
                Type humanType = human.GetType();
                if (humanType == typeof(Mailman))
                {
                    Console.WriteLine("Mailman is working...");
                }
                else
                {
                    Console.WriteLine("Teaching");
                }
            }
        }

        private static void DemoPolymorphism()
        {
            Mailman mailman = new Mailman("Thomas", 29, 78.5f, 190.11f);
            Teacher teacher = new Teacher("Gareth", 35, 100.5f, 186.49f);
            // Specialized types can be stored as their generalized forms.
            Human[] humans = { mailman, teacher };
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
