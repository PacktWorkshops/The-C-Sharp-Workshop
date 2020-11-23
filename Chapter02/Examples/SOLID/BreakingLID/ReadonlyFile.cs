using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02.Examples.SOLID.BreakingLID
{
    public class ReadonlyFile : File
    {
        public ReadonlyFile(Reader reader) : base(reader, new NullWriter())
        {
        }
    }
}
