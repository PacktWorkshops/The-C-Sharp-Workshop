using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Examples.AdventureWorksProduction
{
    public partial class Productreview
    {
        public int Productreviewid { get; set; }
        public int Productid { get; set; }
        public string Reviewername { get; set; }
        public DateTime Reviewdate { get; set; }
        public string Emailaddress { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime Modifieddate { get; set; }

        public virtual Product Product { get; set; }
    }
}
