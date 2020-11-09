namespace Chapter02.Examples.Abstraction.Workers
{
    public static class Demo
    {
        public static void Run()
        {
            DemoAbstractionThroughInheritance();
            DemoAbstractionThroughInterfaces();
        }

        private static void DemoAbstractionThroughInheritance()
        {
            Human mailman = new Mailman("Thomas", 29, 78.5f, 190.11f);
            Human teacher = new Teacher("Gareth", 35, 100.5f, 186.49f);
            //...
            mailman.Work();
            teacher.Work();
        }

        private static void DemoAbstractionThroughInterfaces()
        {
            IWorker human = new Mailman("Thomas", 29, 78.5f, 190.11f);
            IWorker ant = new Ant();
            IWorker robot = new Robot();

            IWorker[] workers = {human, ant, robot};
            foreach (var worker in workers)
            {
                worker.Work();
            }
        }
    }
}
