using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Examples.AdventureWorksProduction
{
    public partial class Transactionhistoryarchive
    {
        public int Transactionid { get; set; }
        public int Productid { get; set; }
        public int Referenceorderid { get; set; }
        public int Referenceorderlineid { get; set; }
        public DateTime Transactiondate { get; set; }
        public char Transactiontype { get; set; }
        public int Quantity { get; set; }
        public decimal Actualcost { get; set; }
        public DateTime Modifieddate { get; set; }
    }
}
