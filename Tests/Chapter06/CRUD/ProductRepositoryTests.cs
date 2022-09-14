using System.Linq;
using Chapter06.Examples.Crud;
using Chapter06.Examples.TalkingWithDb.Orm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter06.CRUD
{
    [TestClass]
    public class ProductRepositoryTests
    {
        private ProductRepository _productRepository;
        // Needed to escape error, such as entity already being tracked and similar, to escape invalid state of the context under test.
        private ProductRepository _isolatedRepo;

        private FactoryDbContext _db;

        [TestInitialize]
        public void Setup()
        {
            _db = new FactoryDbContext();
            _productRepository = new ProductRepository(_db);
            _isolatedRepo = new ProductRepository(new FactoryDbContext());
        }

        [TestCleanup]
        public void Teardown()
        {
            _productRepository.Dispose();
            _isolatedRepo.Dispose();
        }

        [TestMethod]
        public void GetById_WhenExisting_ReturnsExpected()
        {
            const int existingProductId = 7;

            var product = _productRepository.GetById(existingProductId);

            Assert.AreEqual(existingProductId, product.Id);
        }

        [TestMethod]
        public void GetByName_WhenExisting_ReturnsExpected()
        {
            _db.Products.Add(new Product() { Name = "Toy Car", Manufacturer = new Manufacturer() {Name = "Test", Country = "Test"}});
            _db.SaveChanges();

            const string existingProductName = "Toy Car";

            var product = _productRepository.GetByName(existingProductName);

            Assert.AreEqual(existingProductName, product.Name.Trim());
        }

        [TestMethod]
        public void GetByManufacturer_WhenExisting_ReturnsExpected()
        {
            const int existingManufacturerId = 1;

            var products = _productRepository.GetByManufacturer(existingManufacturerId);

            Assert.IsTrue(products.Any(), "The manufacturer should have at least 1 product");
        }

        [TestMethod]
        public void GetById_WhenNotExisting_ReturnsNull()
        {
            const int notExistingProductId = int.MaxValue;

            var product = _productRepository.GetById(notExistingProductId);

            Assert.IsNull(product);
        }

        [TestMethod]
        public void GetByName_WhenNotExisting_ReturnsNull()
        {
            const string notExistingProductName = "-";

            var product = _productRepository.GetByName(notExistingProductName);

            Assert.IsNull(product);
        }

        [TestMethod]
        public void GetByManufacturer_WhenNotExisting_ReturnsNull()
        {
            const int notExistingManufacturerId = int.MaxValue;

            var products = _productRepository.GetByManufacturer(notExistingManufacturerId);

            Assert.AreEqual(0, products.Count());
        }

        [TestMethod]
        public void Create_AddsProduct()
        {
            var product = new Product
            {
                Name = "Teddy Bear",
                Price = 10,
                ManufacturerId = 1
            };

            _productRepository.Create(product);

            var addedProduct = _productRepository.GetByName("Teddy Bear");
            Assert.AreEqual(product.Name.Trim(), addedProduct.Name.Trim());

            _productRepository.Delete("Teddy Bear");
        }

        [TestMethod]
        public void UpdateEntry_GivenProductExists_Updates()
        {
            var existingProduct = new Product
            {
                Name = "Teddy Bear",
                Price = 10,
                ManufacturerId = 1
            };
            _productRepository.Create(existingProduct);
            var existingProductId = _productRepository.GetByName("Teddy Bear").Id;
            var productUpdate = new Product
            {
                Id = existingProductId,
                Price = 45.99m
            };

            try
            {
                _productRepository.UpdateUsingEntry(productUpdate);

                var updatedProduct = _productRepository.GetByName("Teddy Bear");
                Assert.AreEqual(productUpdate.Price, updatedProduct.Price);
            }
            finally
            {
                _productRepository.Delete("Teddy Bear");
            }
        }

        [TestMethod]
        public void UpdateUsingFound_GivenProductExists_Updates()
        {
            var existingProduct = new Product
            {
                Name = "Teddy Bear",
                Price = 10,
                ManufacturerId = 1
            };
            _productRepository.Create(existingProduct);
            var existingProductId = _productRepository.GetByName("Teddy Bear").Id;
            var productUpdate = new Product
            {
                Id = existingProductId,
                Price = 45.99m
            };

            try
            {
                _productRepository.UpdateUsingFound(productUpdate);

                var updatedProduct = _productRepository.GetByName("Teddy Bear");
                Assert.AreEqual(productUpdate.Price, updatedProduct.Price);
            }
            finally
            {
                _productRepository.Delete("Teddy Bear");
            }
        }

        [TestMethod]
        public void UpdateUsingUpdate_GivenProductExists_Updates()
        {
            var existingProduct = new Product
            {
                Name = "Teddy Bear",
                Price = 10,
                ManufacturerId = 1
            };
            _isolatedRepo.Create(existingProduct);
            // To get id
            existingProduct = _isolatedRepo.GetByName("Teddy Bear");
            var productUpdate = new Product
            {
                Id = existingProduct.Id,
                Price = 45.99m,
                ManufacturerId = existingProduct.ManufacturerId,
                Name = existingProduct.Name
            };

            try
            {
                _productRepository.UpdateUsingUpdate(productUpdate);

                var updatedProduct = _productRepository.GetByName("Teddy Bear");
                Assert.AreEqual(productUpdate.Price, updatedProduct.Price);
            }
            finally
            {
                _isolatedRepo.Delete("Teddy Bear");
            }
        }

        [TestMethod]
        public void DeleteDirect_GivenProductExists_RemovesThatProduct()
        {
            var product = new Product
            {
                ManufacturerId = 1,
                Name = "New one",
                Price = 0
            };

            _productRepository.Create(product);
            var newProduct = _productRepository.GetByName("New one");

            _productRepository.DeleteDirectly(newProduct.Id);

            var deletedProduct = _productRepository.GetByName("New one");
            Assert.IsNull(deletedProduct);
        }
    }
}
