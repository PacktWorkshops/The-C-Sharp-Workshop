using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chapter06.Examples.TalkingWithDb.Orm;
using Microsoft.EntityFrameworkCore;

namespace Chapter06.Examples.Repository
{
    public static class Demo
    {
        public static void Test()
        {
            var builder = new DbContextOptionsBuilder<FactoryDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            var options = builder.Options;
            var db = new FactoryDbContext(options);

            var productsRepository = new Repository<Product>(db);

            var product = new Product {Name = "Test PP", ManufacturerId = 1, Price = 9.99m};
            var id = productsRepository.Create(product);

            product.Price = 19m;
            productsRepository.Update(product);

            var productAfterChanges = productsRepository.Get(id);
            Console.WriteLine($"Id: {productAfterChanges.Id}, " +
                              $"Name: {productAfterChanges.Name}, " +
                              $"Price: {productAfterChanges.Price}");

            var productToDelete = new Product { Name = "Test PP 2", ManufacturerId = 1, Price = 9.99m };
            var idToDelete = productsRepository.Create(productToDelete);
            var countBeforeDelete = productsRepository.Get().Count();
            productsRepository.Delete(idToDelete);
            var countAfter = productsRepository.Get().Count();
            Console.WriteLine($"Before: {countBeforeDelete}, after: {countAfter}");
        }
    }
}
