using Chapter06.Examples.TalkingWithDb.Orm;

namespace Chapter06.Examples.Crud
{
    public static class Demo
    {
        public static void Run()
        {
            var dbContext = new FactoryDbContext();

            var productsRepo = new ProductRepository(dbContext);
            productsRepo.Create(new Product { Name = "Test1", ManufacturerId = 3 });
            productsRepo.Create(new Product { Name = "Test2", ManufacturerId = 3 });
            productsRepo.Create(new Product { Name = "Test3", ManufacturerId = 3 });
            var productByName = productsRepo.GetByName("Test1");
            var productById = productsRepo.GetById(productByName.Id);
            productsRepo.Delete("Test2");
            productsRepo.Delete(productById.Id);
            productById = productsRepo.GetByName("Test3");
            productsRepo.DeleteDirectly(productById.Id);

            var manufacturersRepo = new ManufacturersRepository(dbContext);
            manufacturersRepo.Create(new Manufacturer { Name = "TestManufacturer", Country = "Country" });
            manufacturersRepo.GetManufacturerAndProductNamePairs_LINQ();
            manufacturersRepo.GetManufacturerAndProductNamePairs_Query();

            dbContext.Dispose();
        }
    }
}
