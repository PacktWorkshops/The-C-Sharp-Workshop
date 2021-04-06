using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Examples.AdventureWorksProduction
{
    public partial class Culture
    {
        public Culture()
        {
            Productmodelproductdescriptioncultures = new HashSet<Productmodelproductdescriptionculture>();
        }

        public string Cultureid { get; set; }
        public string Name { get; set; }
        public DateTime Modifieddate { get; set; }

        public virtual ICollection<Productmodelproductdescriptionculture> Productmodelproductdescriptioncultures { get; set; }
    }
}
