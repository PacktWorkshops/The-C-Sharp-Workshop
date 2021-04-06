using System;
using System.Collections.Generic;
using System.Linq;
using Chapter06.Examples.Custom;
using Chapter06.Examples.TalkingWithDb.Orm;
using Microsoft.EntityFrameworkCore;

namespace Chapter06.Examples.CRUD
{
    public class ManufacturersRepository : IDisposable
    {
        private readonly FactoryDbContext db;

        public ManufacturersRepository(FactoryDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Manufacturer> Get()
        {
            return db.Manufacturers
                .Include(m => m.Products)
                .ToList();
        }

        public IEnumerable<(string, string)> GetManufacturerAndProductNamePairs_Query()
        {
            var productAndManufactuerPairs =
                (from p in db.Products
                 join m in db.Manufacturers
                    on p.ManufacturerId equals m.Id
                 select new {Product = p.Name, Manufacturer = m.Name}
                ).ToList();

            return productAndManufactuerPairs.Select(p => (p.Product, p.Manufacturer));
        }

        public IEnumerable<(string, string)> GetManufacturerAndProductNamePairs_LINQ()
        {
            var productAndManufactuerPairs = 
                db.Products
                .Join(db.Manufacturers,
                    p => p.ManufacturerId, m => m.Id,
                    (p, m) => new {Product = p.Name, Manufacturer = m.Name})
                .ToList();

             return productAndManufactuerPairs.Select(p => (p.Product, p.Manufacturer));
        }

        public void Create(Manufacturer manufacturer)
        {
            db.Manufacturers.Add(manufacturer);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
