using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chapter06.Exercises.Exercise03
{
    [Table("location", Schema = "production")]
    public class Location
    {
        [Column("locationid")]
        public int LocationId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("costrate")]
        public double Costrate { get; set; }
        [Column("availability")]
        public double Availability { get; set; }
        [Column("modifieddate")]
        public DateTime ModifiedDate { get; set; }
    }
}
