using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Examples.AdventureWorksProduction
{
    public partial class Productcosthistory
    {
        public int Productid { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public decimal Standardcost { get; set; }
        public DateTime Modifieddate { get; set; }

        public virtual Product Product { get; set; }
    }
}
