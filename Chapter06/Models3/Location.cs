using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Models3
{
    public partial class Location
    {
        public Location()
        {
            Productinventories = new HashSet<Productinventory>();
        }

        public int Locationid { get; set; }
        public string Name { get; set; }
        public decimal Costrate { get; set; }
        public decimal Availability { get; set; }
        public DateTime Modifieddate { get; set; }

        public virtual ICollection<Productinventory> Productinventories { get; set; }
    }
}
