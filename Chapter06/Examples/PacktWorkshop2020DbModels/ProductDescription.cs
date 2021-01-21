using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Models
{
    public partial class ProductDescription
    {
        public ProductDescription()
        {
            ProductModelProductDescriptions = new HashSet<ProductModelProductDescription>();
        }

        public int ProductDescriptionId { get; set; }
        public string Description { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }
    }
}
