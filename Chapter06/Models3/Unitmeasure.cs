using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Models3
{
    public partial class Unitmeasure
    {
        public Unitmeasure()
        {
            Billofmaterials = new HashSet<Billofmaterial>();
            ProductSizeunitmeasurecodeNavigations = new HashSet<Product>();
            ProductWeightunitmeasurecodeNavigations = new HashSet<Product>();
        }

        public string Unitmeasurecode { get; set; }
        public string Name { get; set; }
        public DateTime Modifieddate { get; set; }

        public virtual ICollection<Billofmaterial> Billofmaterials { get; set; }
        public virtual ICollection<Product> ProductSizeunitmeasurecodeNavigations { get; set; }
        public virtual ICollection<Product> ProductWeightunitmeasurecodeNavigations { get; set; }
    }
}
