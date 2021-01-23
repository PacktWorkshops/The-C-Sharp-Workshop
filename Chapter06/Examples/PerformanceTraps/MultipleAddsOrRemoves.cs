using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chapter06.Activities.Activity02;

namespace Chapter06.Examples.PerformanceTraps
{
    public static class MultipleAddsOrRemoves
    {
        public static void Slow()
        {
            var db = new GlobalFactory2020Context();

            var productName = "DummyP";
            for (int i = 0; i < 1000; i++)
            {
                var product = new Activities.Activity02.Product
                {
                    Name = productName,
                    Price = 11,
                    ManufacturerId = 2
                };
                db.Products.Add(product);
            }

            var toRemoves = db.Products.Where(p => p.Name == productName).ToList();
            foreach (var toRemove in toRemoves)
            {
                db.Products.Remove(toRemove);
            }

            db.Dispose();
        }

        public static void Fast()
        {
            var db = new GlobalFactory2020Context();

            var productName = "DummyP";
            var toAdd = new List<Activities.Activity02.Product>();
            for (int i = 0; i < 1000; i++)
            {
                var product = new Activities.Activity02.Product
                {
                    Name = productName,
                    Price = 11,
                    ManufacturerId = 2
                };
                toAdd.Add(product);
            }
            db.Products.AddRange(toAdd);

            var toRemoves = db.Products.Where(p => p.Name == productName).ToList();
            db.Products.RemoveRange(toRemoves);

            db.Dispose();
        }
    }
}
