using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Models3
{
    public partial class Productmodelproductdescriptionculture
    {
        public int Productmodelid { get; set; }
        public int Productdescriptionid { get; set; }
        public string Cultureid { get; set; }
        public DateTime Modifieddate { get; set; }

        public virtual Culture Culture { get; set; }
        public virtual Productdescription Productdescription { get; set; }
        public virtual Productmodel Productmodel { get; set; }
    }
}
