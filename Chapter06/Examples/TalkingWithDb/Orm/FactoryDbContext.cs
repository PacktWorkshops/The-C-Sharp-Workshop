using System.Diagnostics;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Program.GlobalFactoryConnectionString);
            }
        }
    }
}
