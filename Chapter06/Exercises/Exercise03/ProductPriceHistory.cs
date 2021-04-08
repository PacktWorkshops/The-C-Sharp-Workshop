using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter06.Exercises.Exercise03
{
    public class ProductPriceHistory
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfPrice { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
