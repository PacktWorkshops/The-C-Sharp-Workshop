using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chapter06.Examples.GlobalFactory2021;
using Microsoft.EntityFrameworkCore;

namespace Chapter06.Examples.PerformanceTraps
{
    public static class LightweightEf
    {
        public static void Default()
        {
            var db = new globalfactory2021Context();

            var product = db.Products
                .ToList();

            db.Dispose();
        }

        public static void AsNoTracking()
        {
            var db = new globalfactory2021Context();

            var product = db.Products
                .AsNoTracking()
                .ToList();

            db.Dispose();
        }
    }
}
