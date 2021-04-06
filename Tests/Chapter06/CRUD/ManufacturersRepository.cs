using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter06.Examples;
using Chapter06.Examples.CRUD;
using Chapter06.Examples.Custom;
using Chapter06.Examples.TalkingWithDb.Orm;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter06.CRUD
{
    [TestClass]
    public class ManufacturersRepositoryTests
    {
        private ManufacturersRepository _manufacturersRepository;
        private FactoryDbContext _db;

        [TestInitialize]
        public void Setup()
        {
            var builder = new DbContextOptionsBuilder<FactoryDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            var options = builder.Options;
            _db = new FactoryDbContext(options);
            _manufacturersRepository = new ManufacturersRepository(_db);
        }

        [TestCleanup]
        public void Teardown()
        {
            _manufacturersRepository.Dispose();
        }

        [TestMethod]
        public void Get_ReturnsAllManufacturers()
        {
            var manufacturers = _manufacturersRepository.Get();

            Assert.AreEqual(1, manufacturers.Count());
            Assert.AreEqual(2, manufacturers.First().Products.Count);
        }

        [TestMethod]
        public void GetManufacturerAndProductNamePairs_LINQ_Returns_Many_Product_Manufacturer()
        {
            var productAndManufacturerPairs = _manufacturersRepository.GetManufacturerAndProductNamePairs_LINQ();
            
            Assert.AreEqual(2, productAndManufacturerPairs.Count());
            foreach (var productAndManufacturerPair in productAndManufacturerPairs)
            {
                Assert.IsNotNull(productAndManufacturerPair.Item1);
                Assert.IsNotNull(productAndManufacturerPair.Item2);
            }
        }

        [TestMethod]
        public void GetManufacturerAndProductNamePairs_Query_Returns_Many_Product_Manufacturer()
        {
            var productAndManufacturerPairs = _manufacturersRepository.GetManufacturerAndProductNamePairs_Query();

            Assert.AreEqual(2, productAndManufacturerPairs.Count());
            foreach (var productAndManufacturerPair in productAndManufacturerPairs)
            {
                Assert.IsNotNull(productAndManufacturerPair.Item1);
                Assert.IsNotNull(productAndManufacturerPair.Item2);
            }
        }

        [TestMethod]
        public void Create_WhenManufactuerWithTwoProducts_AddsEntriesToDb()
        {
            var manufacturer = new Manufacturer
            {
                Country = "Lithuania",
                Name = "Toy Lasers",
                Products = new List<Product>
                {
                    new()
                    {
                        Name = "Laser S",
                        Price = 4.01m
                    },
                    new()
                    {
                        Name = "Laser M",
                        Price = 7.99m
                    }
                }
            };

            _manufacturersRepository.Create(manufacturer);

            var toyLasersManufacturer = _db.Manufacturers
                .Include(m => m.Products)
                .Where(m => m.Name == "Toy Lasers");

            Assert.AreEqual(2, toyLasersManufacturer.First().Products.Count);

            _db.Manufacturers.RemoveRange(toyLasersManufacturer);
            _db.SaveChanges();
        }
    }
}
