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
            : base(UseSqlServerOptions())
        {
        }

        protected static DbContextOptions UseSqlServerOptions()
        {
            return new DbContextOptionsBuilder()
                .UseSqlServer(Program.ConnectionString)
                .Options;
        }

        // Prevents from using different providers- avoid.
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(Program.ConnectionString);
        //}
    }
}
