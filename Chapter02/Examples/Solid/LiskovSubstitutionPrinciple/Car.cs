using System;

namespace Chapter02.Examples.Solid.LiskovSubstitutionPrinciple
{
    class Car
    {
        public object Body { get; set; }

        public virtual void Move()
        {
            // Moving
        }
    }

    class CarWreck : Car
    {
        public override void Move()
        {
            throw new NotSupportedException("A broken car cannot start.");
        }
    }
}
