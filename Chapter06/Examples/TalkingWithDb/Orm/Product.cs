using System.ComponentModel.DataAnnotations.Schema;
using Chapter06.Examples.Repo;

namespace Chapter06.Examples.TalkingWithDb.Orm
{
    [Table("product", Schema = "factory")]
    public class Product : IAggregate
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
