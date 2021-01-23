using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chapter06.Activities.Activity02;
using Microsoft.EntityFrameworkCore;

namespace Chapter06.Examples
{
    public static class DataSeeding
    {
        public const string ManufacturerName = "Test Factory";
        public const string TestProduct1Name = "Product1     ";
        /// <summary>
        /// Padding should be 13 right.
        /// </summary>
        public const string TestProduct2NameNotPadded = "Product2";
        public const decimal MaxPrice = 1000;

        public static void SeedDataIfWasntSeededBefore()
        {
            var db = new GlobalFactory2020Context();
            bool isDataAlreadySeeded = db.Manufacturers.Any(m => m.Name == ManufacturerName);
            if (isDataAlreadySeeded) return;

            SeedData(db);
        }

        private static void SeedData(GlobalFactory2020Context db)
        {
            var manufacturer = new Activities.Activity02.Manufacturer
            {
                Country = "Test country",
                Name = ManufacturerName
            };

            var products = new List<Activities.Activity02.Product>();
            var random = new Random();
            for (var i = 0; i < 10000; i++)
            {
                var product = new Activities.Activity02.Product
                {
                    Name = (i % 2 == 0) ? TestProduct1Name : TestProduct2NameNotPadded.PadRight(13),
                    Manufacturer = manufacturer,
                    Price = (decimal) random.NextDouble() * MaxPrice
                };

                products.Add(product);
            }

            manufacturer.Products = products;

            db.Manufacturers.Add(manufacturer);
            db.SaveChanges();
            db.Dispose();
        }
    }
}
