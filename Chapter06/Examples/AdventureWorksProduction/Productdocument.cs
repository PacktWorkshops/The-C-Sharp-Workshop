using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Examples.AdventureWorksProduction
{
    public partial class Productdocument
    {
        public int Productid { get; set; }
        public DateTime Modifieddate { get; set; }
        public string Documentnode { get; set; }

        public virtual Document DocumentnodeNavigation { get; set; }
        public virtual Product Product { get; set; }
    }
}
