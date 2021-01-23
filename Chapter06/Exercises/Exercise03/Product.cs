using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace Chapter06.Exercises.Exercise03
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

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<ProductPriceHistory> PriceHistory { get; set; }
    }
}
