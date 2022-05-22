using Microsoft.EntityFrameworkCore;

namespace Chapter06.Exercises.Exercise01
{
    public class AdventureWorksContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }

        public AdventureWorksContext()
            : base(UsePostgreSqlServerOptions())
        {
        }

        protected static DbContextOptions UsePostgreSqlServerOptions()
        {
            return new DbContextOptionsBuilder()
                .UseNpgsql(Program.AdventureWorksConnectionString)
                .Options;
        }

        public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options)
            : base(options)
        {
        }
    }
}
