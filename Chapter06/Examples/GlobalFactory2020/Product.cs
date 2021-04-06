using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Examples.GlobalFactory2020
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Manufacturerid { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
