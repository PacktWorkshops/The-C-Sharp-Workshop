using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter06.Examples.TalkingWithDb.Orm;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Chapter06.Examples.TestingDb
{
    public static class Sqlite
    {
        public static void TestSqlite()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            var builder = new DbContextOptionsBuilder<FactoryDbContext>();
            builder.UseSqlite(connection);
            var options = builder.Options;
            var db = new FactoryDbContext(options);
            db.Database.EnsureCreated();

            Test.Run(db);

            connection.Dispose();
        }
    }
}
