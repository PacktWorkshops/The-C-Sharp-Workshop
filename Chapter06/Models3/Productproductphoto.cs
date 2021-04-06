using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Models3
{
    public partial class Productproductphoto
    {
        public int Productid { get; set; }
        public int Productphotoid { get; set; }
        public bool Primary { get; set; }
        public DateTime Modifieddate { get; set; }

        public virtual Product Product { get; set; }
        public virtual Productphoto Productphoto { get; set; }
    }
}
