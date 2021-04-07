using System;
using System.Linq;
using Chapter06.Examples.GlobalFactory2021;
using Microsoft.EntityFrameworkCore;

namespace Chapter06.Examples.PerformanceTraps
{
    public static class Loading
    {
        public static void Lazy()
        {
            var db = new globalfactory2021Context();

            var product = db.Products.First();
            // Lazy loaded
            var manufacturer = product.Manufacturer;

            db.Dispose();
        }

        public static void Eager()
        {
            var db = new globalfactory2021Context();

            var manufacturer = db.Products
                // Eager loaded
                .Include(p => p.Manufacturer)
                .First()
                .Manufacturer;

            db.Dispose();
        }
    }
}
