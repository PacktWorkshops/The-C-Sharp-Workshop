using System;

namespace Chapter02.Examples.Solid.LiskovSubstitutionPrinciple;

class CarWreck : Car
{
    public override void Move()
    {
        throw new NotSupportedException("A broken car cannot start.");
    }
}