using System.ComponentModel.DataAnnotations.Schema;

namespace Chapter06.Examples
{
    [Table("product", Schema = "factory")]
    public class Product
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("manufacturerid")]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
