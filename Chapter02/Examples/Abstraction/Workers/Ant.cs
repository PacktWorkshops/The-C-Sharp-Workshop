using System;

namespace Chapter02.Examples.Abstraction.Workers
{
    public class Ant : IWorker
    {
        public void Work()
        {
            Console.WriteLine("Ant is working hard.");
        }
    }
}
