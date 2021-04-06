using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Examples.AdventureWorksProduction
{
    public partial class Productmodel
    {
        public Productmodel()
        {
            Productmodelillustrations = new HashSet<Productmodelillustration>();
            Productmodelproductdescriptioncultures = new HashSet<Productmodelproductdescriptionculture>();
            Products = new HashSet<Product>();
        }

        public int Productmodelid { get; set; }
        public string Name { get; set; }
        public string Catalogdescription { get; set; }
        public string Instructions { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime Modifieddate { get; set; }

        public virtual ICollection<Productmodelillustration> Productmodelillustrations { get; set; }
        public virtual ICollection<Productmodelproductdescriptionculture> Productmodelproductdescriptioncultures { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
