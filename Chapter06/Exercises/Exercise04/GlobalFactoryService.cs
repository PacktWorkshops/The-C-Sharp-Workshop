using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chapter06.Examples;
using Chapter06.Examples.TalkingWithDb.Orm;
using Microsoft.EntityFrameworkCore;

namespace Chapter06.Exercises.Exercise04
{
    public class GlobalFactoryService : IDisposable
    {
        private readonly FactoryDbContext _context;

        public GlobalFactoryService(FactoryDbContext context)
        {
            _context = context;
        }

        public void CreateManufacturersInUsa(IEnumerable<string> names)
        {
            var manufacturers = names
                .Select(name => new Manufacturer()
                {
                    Name = name,
                    Country = "USA"
                });

            _context.Manufacturers.AddRange(manufacturers);
            _context.SaveChanges();
        }

        public void CreateUsaProducts(IEnumerable<Product> products)
        {
            var manufacturersInUsa = _context
                .Manufacturers
                .Where(m => m.Country == "USA")
                .ToList();

            foreach (var product in products)
            {
                manufacturersInUsa.ForEach(m => m.Products.Add(
                    new Product {Name = product.Name, Price = product.Price}
                    ));
            }

            _context.SaveChanges();
        }

        public void SetAnyUsaProductOnDiscount(decimal discountedPrice)
        {
            var anyroductInUsa = _context
                .Products
                .FirstOrDefault(p => p.Manufacturer.Country == "USA");

            anyroductInUsa.Price = discountedPrice;

            _context.SaveChanges();
        }

        public void RemoveAnyProductInUsa()
        {
            var firstProductInUsa = _context
                .Products
                .FirstOrDefault(p => p.Manufacturer.Country == "USA");

            _context.Remove(firstProductInUsa);
            _context.SaveChanges();
        }

        public IEnumerable<Manufacturer> GetManufacturersInUsa()
        {
            var manufacturersFromUsa = _context
                .Manufacturers
                .Include(m => m.Products)
                .Where(m => m.Country == "USA")
                .ToList();

            return manufacturersFromUsa;
        }

        public void Dispose() => _context.Dispose();
    }
}
