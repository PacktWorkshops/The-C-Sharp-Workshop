using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Models
{
    public partial class SalesOrderDetail
    {
        public int SalesOrderId { get; set; }
        public int SalesOrderDetailId { get; set; }
        public short OrderQty { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Product1 Product { get; set; }
        public virtual SalesOrderHeader SalesOrder { get; set; }
    }
}
