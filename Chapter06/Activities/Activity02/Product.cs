using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.GlobalFactoryScaffolded
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ManufacturerId { get; set; }

        public virtual Exercises.Exercise03.Manufacturer Manufacturer { get; set; }
    }
}
