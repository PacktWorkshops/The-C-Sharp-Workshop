using System.Linq;
using Chapter06.Examples.TalkingWithDb.Orm;

namespace Chapter06.Examples.Filtering
{
    public class GetProductBy
    {
        public Product GetById(int id)
        {
            using var db = new FactoryDbContext();
            var product = db.Products.Find(id);
            return product;
        }

        public Product GetByName(string name)
        {
            using var db = new FactoryDbContext();
            var product = db.Products.FirstOrDefault(p => p.Name == name);
            return product;
        }

        public Product GetByManufacturer(int manufacturerId)
        {
            using var db = new FactoryDbContext();
            var product = db.Products.FirstOrDefault(p => p.Manufacturer.Id == manufacturerId);
            return product;
        }
    }
}
