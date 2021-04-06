using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Examples.AdventureWorksProduction
{
    public partial class Productcategory
    {
        public Productcategory()
        {
            Productsubcategories = new HashSet<Productsubcategory>();
        }

        public int Productcategoryid { get; set; }
        public string Name { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime Modifieddate { get; set; }

        public virtual ICollection<Productsubcategory> Productsubcategories { get; set; }
    }
}
