using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace Chapter06.Exercises.Exercise04
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }

        public decimal GetPrice() => PriceHistory
            .Where(p => p.ProductId == Id)
            .OrderByDescending(p => p.DateOfPrice)
            .First().Price;

        public Manufacturer Manufacturer { get; set; }
        public ICollection<ProductPriceHistory> PriceHistory { get; set; }
    }
}
