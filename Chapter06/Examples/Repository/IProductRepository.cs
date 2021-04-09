using System.Collections.Generic;
using Chapter06.Examples.GlobalFactory2021;

namespace Chapter06.Examples.Repository
{
    public interface IProductRepository
    {
        int Create(Product product);
        void Delete(int id);
        void Update(Product product);
        Product Get(int id);
        IEnumerable<Product> Get();
    }
}