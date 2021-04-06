using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Examples.AdventureWorksProduction
{
    public partial class Productlistpricehistory
    {
        public int Productid { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public decimal Listprice { get; set; }
        public DateTime Modifieddate { get; set; }

        public virtual Product Product { get; set; }
    }
}
