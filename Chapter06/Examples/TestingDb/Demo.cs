using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06.Examples.TestingDb
{
    public static class Demo
    {
        public static void Run()
        {
            InMemory.TestInMemory();
            Sqlite.TestSqlite();
        }
    }
}
