using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter06.Examples.TalkingWithDb.Orm;
using Microsoft.EntityFrameworkCore;

namespace Chapter06.Examples.TestingDb
{
    public static class InMemory
    {
        public static void TestInMemory()
        {
            var builder = new DbContextOptionsBuilder<FactoryDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            var options = builder.Options;
            var db = new FactoryDbContext(options);

            Test.Run(db);
        }
    }
}
