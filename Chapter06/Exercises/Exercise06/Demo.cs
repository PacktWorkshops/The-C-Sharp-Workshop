﻿using System;
using System.Linq;
using Chapter06.Examples.TalkingWithDb.Orm;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Chapter06.Exercises.Exercise06
{
    public static class Demo
    {
        public static void TestManufacturerPgsql()
        {
            var db = new FactoryDbContext();

            var manufacturersRepository = new Repository<Manufacturer>(db);

            var manufacturer = new Manufacturer { Country = "Lithuania", Name = "Tomo Baldai" };
            var id = manufacturersRepository.Create(manufacturer);

            manufacturer.Name = "New Name";
            manufacturersRepository.Update(manufacturer);

            var manufacturerAfterChanges = manufacturersRepository.Get(id);
            Console.WriteLine($"Id: {manufacturerAfterChanges.Id}, " +
                              $"Name: {manufacturerAfterChanges.Name}");

            var countBeforeDelete = manufacturersRepository.Get().Count();
            manufacturersRepository.Delete(id);
            var countAfter = manufacturersRepository.Get().Count();
            Console.WriteLine($"Before: {countBeforeDelete}, after: {countAfter}");
        }

        public static void TestInMemory()
        {
            var builder = new DbContextOptionsBuilder<FactoryDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            var options = builder.Options;
            var db = new FactoryDbContext(options);

            Test(db);
        }

        public static void TestSqlite()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            
            var builder = new DbContextOptionsBuilder<FactoryDbContext>();
            builder.UseSqlite(connection);
            var options = builder.Options;
            var db = new FactoryDbContext(options);
            db.Database.EnsureCreated();
            
            Test(db);

            connection.Dispose();
        }

        private static void Test(FactoryDbContext db)
        {
            var productsRepository = new Repository<Product>(db);
            var manufacturer = new Manufacturer() { Id = 1 };
            db.Manufacturers.Add(manufacturer);
            db.SaveChanges();

            var product = new Product { Name = "Test PP", ManufacturerId = 1, Price = 9.99m };
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