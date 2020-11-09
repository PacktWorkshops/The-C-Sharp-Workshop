using System;
using System.Collections.Generic;
using System.Text;

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
