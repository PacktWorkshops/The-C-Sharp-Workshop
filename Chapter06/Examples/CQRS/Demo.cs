using System;
using System.Linq;
using Chapter06.Examples.Repository;
using Chapter06.Examples.TalkingWithDb.Orm;
using Microsoft.EntityFrameworkCore;

namespace Chapter06.Examples.Cqrs
{
    public static class Demo
    {
        public static void Test()
        {
            var builder = new DbContextOptionsBuilder<FactoryDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            var options = builder.Options;
            var db = new FactoryDbContext(options);

            var command = new CreateProductCommand { Name = "Test PP", Manufacturerid = 1, Price = 9.99m };
            var commandHandler = new CreateProductCommandHandler(db);
            var newProductId = commandHandler.Handle(command);

            var query = newProductId;
            var queryHandler = new GetProductQueryHandler(db);
            var product = queryHandler.Handle(query);
            Console.WriteLine($"Id: {product.Id}, " +
                              $"Name: {product.Name}, " +
                              $"Price: {product.Price}");
        }
    }
}
