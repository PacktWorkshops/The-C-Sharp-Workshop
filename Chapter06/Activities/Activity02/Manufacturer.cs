using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.GlobalFactoryScaffolded
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Products = new HashSet<Exercises.Exercise03.Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime FoundedAt { get; set; }

        public virtual ICollection<Exercises.Exercise03.Product> Products { get; set; }
    }
}
