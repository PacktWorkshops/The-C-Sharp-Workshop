﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Chapter06.Exercises.Exercise05
{
    public static class Demo
    {
        public static void Run()
        {
            var db = new globalfactory2021Contextv3();
            var manufacturer = new Manufacturer
            {
                Country = "Canada",
                FoundedAt = DateTime.Now,
                Name = "Fake Toys"
            };

            var product = new Product
            {
                Name = "Rubber Sweater",
                Manufacturer = manufacturer
            };

            var priceHistory = new List<ProductPriceHistory>
            {
                new ProductPriceHistory
                {
                    DateOfPrice = DateTime.Now.AddDays(-10),
                    Price = 15.11m,
                    Product = product
                },
                new ProductPriceHistory
                {
                    DateOfPrice = DateTime.Now,
                    Price = 15.5m,
                    Product = product
                }
            };

            product.PriceHistory = priceHistory;
            manufacturer.Products = new List<Product> { product };

            db.Manufacturers.Add(manufacturer);
            db.SaveChanges();

            db.Dispose();

            var db1 = new globalfactory2021Contextv3();
            var manufacturerAfterAddition = db1.Manufacturers
                .Include(m => m.Products)
                .ThenInclude(p => p.PriceHistory)
                .First(m => m.Name == "Fake Toys");

            var productAfterAddition = manufacturerAfterAddition.Products.First();

            Console.WriteLine($"{manufacturerAfterAddition.Name} {productAfterAddition.Name} {productAfterAddition.GetPrice()}");
            db1.Dispose();
        } 
    }
}