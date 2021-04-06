using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Models3
{
    public partial class Transactionhistory
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

        public virtual Product Product { get; set; }
    }
}
