using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Examples.AdventureWorksProduction
{
    public partial class Illustration
    {
        public Illustration()
        {
            Productmodelillustrations = new HashSet<Productmodelillustration>();
        }

        public int Illustrationid { get; set; }
        public string Diagram { get; set; }
        public DateTime Modifieddate { get; set; }

        public virtual ICollection<Productmodelillustration> Productmodelillustrations { get; set; }
    }
}
