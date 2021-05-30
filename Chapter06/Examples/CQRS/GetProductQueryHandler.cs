using Chapter06.Examples.GlobalFactory2021;
using Chapter06.Examples.TalkingWithDb.Orm;
using Product = Chapter06.Examples.TalkingWithDb.Orm.Product;

namespace Chapter06.Examples.CQRS
{
    public class GetProductQueryHandler
    {
        private readonly FactoryDbContext _context;

        public GetProductQueryHandler(FactoryDbContext context)
        {
            _context = context;
        }

        public Product Handle(int id)
        {
            return _context.Products.Find(id);
        }
    }
}
