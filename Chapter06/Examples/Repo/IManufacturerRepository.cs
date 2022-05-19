using System.Collections.Generic;
using Chapter06.Examples.GlobalFactory2021;

namespace Chapter06.Examples.Repo
{
    public interface IManufacturerRepository
    {
        int Create(Manufacturer product);
        void Delete(long id);
        void Update(Manufacturer product);
        Manufacturer Get(long id);
        IEnumerable<Manufacturer> Get();
    }
}