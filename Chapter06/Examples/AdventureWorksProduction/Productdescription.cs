using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Examples.AdventureWorksProduction
{
    public partial class Productdescription
    {
        public Productdescription()
        {
            Productmodelproductdescriptioncultures = new HashSet<Productmodelproductdescriptionculture>();
        }

        public int Productdescriptionid { get; set; }
        public string Description { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime Modifieddate { get; set; }

        public virtual ICollection<Productmodelproductdescriptionculture> Productmodelproductdescriptioncultures { get; set; }
    }
}
