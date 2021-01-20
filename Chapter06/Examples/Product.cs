using System.ComponentModel.DataAnnotations.Schema;

namespace Chapter06.Examples
{
    [Table("Product", Schema = "Factory")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
