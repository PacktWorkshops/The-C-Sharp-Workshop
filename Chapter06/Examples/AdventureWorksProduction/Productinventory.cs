using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Examples.AdventureWorksProduction
{
    public partial class Productinventory
    {
        public int Productid { get; set; }
        public int Locationid { get; set; }
        public string Shelf { get; set; }
        public short Bin { get; set; }
        public short Quantity { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime Modifieddate { get; set; }

        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
