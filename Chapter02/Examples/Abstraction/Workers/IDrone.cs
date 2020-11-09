using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter02.Examples.Abstraction.Workers
{
    public interface IDrone : IWorker, IFlyer
    {
    }
}
