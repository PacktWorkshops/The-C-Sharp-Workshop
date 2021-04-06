using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Models3
{
    public partial class Workorder
    {
        public int Workorderid { get; set; }
        public int Productid { get; set; }
        public int Orderqty { get; set; }
        public short Scrappedqty { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public DateTime Duedate { get; set; }
        public short? Scrapreasonid { get; set; }
        public DateTime Modifieddate { get; set; }

        public virtual Product Product { get; set; }
    }
}
