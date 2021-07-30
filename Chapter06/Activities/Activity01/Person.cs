using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chapter06.Activities.Activity01
{
    [Table("Person", Schema = "TruckLogistics")]
    public class Person
    {
        public int Id { get; set; }
        [MaxLength(300)]
        public string Name { get; set; }
        public DateTime DoB { get; set; }
    }
}
