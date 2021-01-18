using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Chapter06.Examples.TalkingWithDb.Orm
{
    public static class Demo
    {
        public static void Run()
        {
            using var context = new FactoryDbContext();
            var products = context
                .Products
                .Include(p => p.Manufacturer)
                .ToList();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} {product.Manufacturer.Name} {product.Id} {product.Price}");
            }
        }
    }
}
