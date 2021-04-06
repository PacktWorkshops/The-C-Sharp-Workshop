using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Models3
{
    public partial class Billofmaterial
    {
        public int Billofmaterialsid { get; set; }
        public int? Productassemblyid { get; set; }
        public int Componentid { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string Unitmeasurecode { get; set; }
        public short Bomlevel { get; set; }
        public decimal Perassemblyqty { get; set; }
        public DateTime Modifieddate { get; set; }

        public virtual Product Component { get; set; }
        public virtual Product Productassembly { get; set; }
        public virtual Unitmeasure UnitmeasurecodeNavigation { get; set; }
    }
}
