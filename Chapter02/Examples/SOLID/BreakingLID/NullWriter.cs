using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02.Examples.SOLID.BreakingLID
{
    class NullWriter : Writer
    {
        public override void Write(string filePath, string content)
        {
            // Does nothing
        }
    }
}
