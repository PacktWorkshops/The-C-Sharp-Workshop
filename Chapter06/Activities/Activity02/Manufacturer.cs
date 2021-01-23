using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Activities.Activity02
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        //public DateTime FoundedAt { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
