using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter02.Examples.Abstraction.Workers
{
    public class Robot : IWorker
    {
        public void Work()
        {
            Console.WriteLine("Beep boop- I am working.");
        }
    }
}
