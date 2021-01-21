using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Models
{
    public partial class ProductModel
    {
        public ProductModel()
        {
            Product1s = new HashSet<Product1>();
            ProductModelProductDescriptions = new HashSet<ProductModelProductDescription>();
        }

        public int ProductModelId { get; set; }
        public string Name { get; set; }
        public string CatalogDescription { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Product1> Product1s { get; set; }
        public virtual ICollection<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }
    }
}
