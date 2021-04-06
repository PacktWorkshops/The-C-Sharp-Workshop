using System.Collections.Generic;
using Chapter06.Examples.Custom;
using Microsoft.EntityFrameworkCore;

namespace Chapter06.Examples.TalkingWithDb.Orm
{
    public class FactoryDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }


        public FactoryDbContext(DbContextOptions<FactoryDbContext> options)
            : base(options)
        {
        }

        public FactoryDbContext()
            : base(UsePostgreSqlServerOptions())
        {
        }

        protected static DbContextOptions UsePostgreSqlServerOptions()
        {
            return new DbContextOptionsBuilder()
                .UseNpgsql(Program.GlobalFactoryConnectionString)
                .Options;
        }

        // Prevents from using different providers- avoid.
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(Program.GlobalFactoryConnectionString);
        //}
    }
}
