using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Models
{
    public partial class Address
    {
        public Address()
        {
            CustomerAddresses = new HashSet<CustomerAddress>();
            SalesOrderHeaderBillToAddresses = new HashSet<SalesOrderHeader>();
            SalesOrderHeaderShipToAddresses = new HashSet<SalesOrderHeader>();
        }

        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryRegion { get; set; }
        public string PostalCode { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaderBillToAddresses { get; set; }
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaderShipToAddresses { get; set; }
    }
}
