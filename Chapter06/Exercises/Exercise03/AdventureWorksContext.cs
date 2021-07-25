using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter06.Exercises.Exercise03
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
