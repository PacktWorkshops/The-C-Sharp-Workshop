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
            var manufacturers = context
                .Manufacturers
                .Include(p => p.Products)
                .ToList();

            foreach (var manufacturer in manufacturers)
            {
                foreach (var product in manufacturer.Products)
                {
                    Console.WriteLine($"{manufacturer.Name} {product.Name} {product.Id} {product.Price}");
                }
            }
        }
    }
}
