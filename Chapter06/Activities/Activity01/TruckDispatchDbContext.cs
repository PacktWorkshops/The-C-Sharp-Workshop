using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter06.Activities.Activity01
{
    public class TruckDispatchDbContext : DbContext
    {
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<TruckDispatch> TruckDispatches { get; set; }

        public TruckDispatchDbContext()
            : base(UsePostgreSqlServerOptions())
        {
        }

        protected static DbContextOptions UsePostgreSqlServerOptions()
        {
            return new DbContextOptionsBuilder()
                .UseNpgsql(Program.TruckLogisticsConnectionString)
                .Options;
        }

        public TruckDispatchDbContext(DbContextOptions<TruckDispatchDbContext> options)
            : base(options)
        {
        }
    }
}
