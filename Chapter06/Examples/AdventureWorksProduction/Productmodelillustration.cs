using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Examples.AdventureWorksProduction
{
    public partial class Productmodelillustration
    {
        public int Productmodelid { get; set; }
        public int Illustrationid { get; set; }
        public DateTime Modifieddate { get; set; }

        public virtual Illustration Illustration { get; set; }
        public virtual Productmodel Productmodel { get; set; }
    }
}
