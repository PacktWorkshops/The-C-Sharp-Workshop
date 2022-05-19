using System.Collections.Generic;
using Chapter06.Examples.GlobalFactory2021;

namespace Chapter06.Examples.Repo
{
    public interface IProductRepository
    {
        int Create(Product product);
        void Delete(long id);
        void Update(Product product);
        Product Get(long id);
        IEnumerable<Product> Get();
    }
}