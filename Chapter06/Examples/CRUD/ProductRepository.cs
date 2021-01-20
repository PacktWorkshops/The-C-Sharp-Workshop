using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Chapter06.Examples.TalkingWithDb.Orm;

namespace Chapter06.Examples.CRUD
{
    public class ProductRepository : IDisposable
    {
        private readonly FactoryDbContext db;

        public ProductRepository(FactoryDbContext db)
        {
            this.db = db;
        }

        public void Create(Product product)
        {
            db.Products.Add(product); 
            db.SaveChanges();
        }

        public void UpdateUsingFound(Product productUpdate)
        {
            var productToUpdate = db.Products.Find(productUpdate.Id);
            var anyProductToUpdate = productToUpdate != null;
            if (anyProductToUpdate)
            {
                productToUpdate.Name = productUpdate.Name ?? productToUpdate.Name;

                productToUpdate.ManufacturerId = (productUpdate.ManufacturerId != default)
                    ? productUpdate.ManufacturerId
                    : productToUpdate.ManufacturerId;

                productToUpdate.Price = (productUpdate.Price != default)
                    ? productUpdate.Price
                    : productToUpdate.Price;

                db.SaveChanges();
            }
        }

        public void UpdateUsingUpdate(Product productUpdate)
        {
            db.Products.Update(productUpdate);
            db.SaveChanges();
        }

        public void UpdateUsingEntry(Product product)
        {
            var productToUpdate = db.Products.Find(product.Id);
            var anyProductToUpdate = productToUpdate != null;
            if (anyProductToUpdate)
            {
                product.Name ??= productToUpdate.Name;
                product.ManufacturerId = product.ManufacturerId == default
                    ? productToUpdate.ManufacturerId
                    : product.Id;
                db.Entry(productToUpdate).CurrentValues.SetValues(product);
                db.SaveChanges();
            }
        }

        public void Delete(int productId)
        {
            var product = db.Products.Find(productId);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }

        public void Delete(string productName)
        {
            var products = db.Products.Where(p => p.Name == productName);
            db.Products.RemoveRange(products);
            db.SaveChanges();
        }

        public Product GetById(int id)
        {
            var product = db.Products.Find(id);
            return product;
        }

        public Product GetByName(string name)
        {
            var product = db.Products.FirstOrDefault(p => p.Name == name);
            return product;
        }

        public IEnumerable<Product> GetByManufacturer(int manufacturerId)
        {
            var products = db
                .Products
                .Where(p => p.ManufacturerId == manufacturerId)
                .ToList();

            return products;
        }

        public void DeleteDirectly(int id)
        {
            var productToDelete = db.Products.Find(id);
            db.Products.Remove(productToDelete);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
