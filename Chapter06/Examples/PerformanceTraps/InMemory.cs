﻿using System.Collections.Generic;
using System.Linq;
using Chapter06.Examples.GlobalFactory2021;


namespace Chapter06.Examples.PerformanceTraps
{
    public static class InMemory
    {
        public static class ChoosingAClass
        {
            /// <summary>
            /// Key difference: IEnumerable
            /// </summary>
            public static void Slow()
            {
                var db = new globalfactory2021Context();

                IEnumerable<Product> products = db.Products;
                var filtered = products
                    .Where(p => p.Name == DataSeeding.TestProduct1Name)
                    .ToList();

                db.Dispose();
            }

            /// <summary>
            /// Key difference: IQueryable
            /// </summary>
            public static void Fast()
            {
                var db = new globalfactory2021Context();

                // IQueryable is a data structure still able to translate a C# expression to a SQL query.
                // SQL is much faster for lookups than C#.
                // 10 times faster.
                IQueryable<Product> products = db.Products;
                var filtered = products
                    .Where(p => p.Name == DataSeeding.TestProduct1Name)
                    .ToList();

                db.Dispose();
            }
        }

        public static class MethodChoice
        {
            /// <summary>
            /// Key difference: equals
            /// </summary>
            public static void Slow()
            {
                var db = new globalfactory2021Context();

                var filtered = db.Products
                    .Where(p => p.Name.Equals(DataSeeding.TestProduct1Name))
                    .ToList();

                db.Dispose();
            }

            /// <summary>
            /// Key difference: ==
            /// </summary>
            public static void Fast()
            {
                var db = new globalfactory2021Context();

                // Some expressions were meant for direct C#-To-SQL translation.
                // Others, like .equals, were not.
                var filtered = db.Products
                    .Where(p => p.Name == DataSeeding.TestProduct1Name)
                    .ToList();

                db.Dispose();
            }
        }
    }
}
