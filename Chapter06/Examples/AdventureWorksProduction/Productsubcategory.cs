using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Examples.AdventureWorksProduction
{
    public partial class Productsubcategory
    {
        public Productsubcategory()
        {
            Products = new HashSet<Product>();
        }

        public int Productsubcategoryid { get; set; }
        public int Productcategoryid { get; set; }
        public string Name { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime Modifieddate { get; set; }

        public virtual Productcategory Productcategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
