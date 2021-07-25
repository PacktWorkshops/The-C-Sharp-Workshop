using System;
using System.Collections.Generic;
using System.Text;
using Chapter06.Examples;
using Chapter06.Examples.TalkingWithDb.Orm;

namespace Chapter06.Activities.Exercise04
{
    public static class Demo
    {
        public static void Run()
        {
            var service = new GlobalFactoryService(new FactoryDbContext());
            service.CreateManufacturersInUsa(new []{"Best Buy", "Iron Retail"});
            service.CreateUsaProducts(new []
            {
                new Product
                {
                    Name = "Toy computer",
                    Price = 20.99m
                },
                new Product
                {
                    Name = "Loli microphone",
                    Price = 7.51m
                }
            });
            service.SetAnyUsaProductOnDiscount(5);
            service.RemoveAnyFirstProductInUsa();
            var manufacturers = service.GetManufacturersInUsa();

            foreach (var manufacturer in manufacturers)
            {
                Console.WriteLine($"{manufacturer.Name}:");
                foreach (var product in manufacturer.Products)
                {
                    Console.WriteLine($"{product.Name} {product.Price}");
                }
            }

        }
    }
}
