using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Models
{
    public partial class BmiDescription
    {
        public string BodyStatus { get; set; }
        public decimal? MinBmi { get; set; }
        public decimal? MaxBmi { get; set; }
    }
}
