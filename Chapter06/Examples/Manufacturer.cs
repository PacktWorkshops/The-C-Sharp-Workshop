using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chapter06.Examples
{
    [Table("Manufacturer", Schema = "Factory")]
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
