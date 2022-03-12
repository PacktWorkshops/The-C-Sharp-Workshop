using Chapter06.Examples.TalkingWithDb.Orm;

namespace Chapter06.Examples.Cqrs
{
    public class CreateProductCommandHandler
    {
        private readonly FactoryDbContext _context;

        public CreateProductCommandHandler(FactoryDbContext context)
        {
            _context = context;
        }

        public int Handle(CreateProductCommand command)
        {
            var product = new Product
            {
                ManufacturerId = command.Manufacturerid,
                Name = command.Name,
                Price = command.Price
            };

            var added  = _context.Products.Add(product);
            _context.SaveChanges();

            return added.Entity.Id;
        }
    }
}
