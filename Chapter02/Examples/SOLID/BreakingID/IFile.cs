using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02.Examples.SOLID.BreakingID
{
    interface IFile
    {
        string Read(string filePath);
        void Write(string filePath, string content);
    }
}
