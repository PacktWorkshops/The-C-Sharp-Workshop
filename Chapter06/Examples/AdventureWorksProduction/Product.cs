using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Examples.AdventureWorksProduction
{
    public partial class Product
    {
        public Product()
        {
            BillofmaterialComponents = new HashSet<Billofmaterial>();
            BillofmaterialProductassemblies = new HashSet<Billofmaterial>();
            Productcosthistories = new HashSet<Productcosthistory>();
            Productdocuments = new HashSet<Productdocument>();
            Productinventories = new HashSet<Productinventory>();
            Productlistpricehistories = new HashSet<Productlistpricehistory>();
            Productproductphotos = new HashSet<Productproductphoto>();
            Productreviews = new HashSet<Productreview>();
            Transactionhistories = new HashSet<Transactionhistory>();
            Workorders = new HashSet<Workorder>();
        }

        public int Productid { get; set; }
        public string Name { get; set; }
        public string Productnumber { get; set; }
        public bool? Makeflag { get; set; }
        public bool? Finishedgoodsflag { get; set; }
        public string Color { get; set; }
        public short Safetystocklevel { get; set; }
        public short Reorderpoint { get; set; }
        public decimal Standardcost { get; set; }
        public decimal Listprice { get; set; }
        public string Size { get; set; }
        public string Sizeunitmeasurecode { get; set; }
        public string Weightunitmeasurecode { get; set; }
        public decimal? Weight { get; set; }
        public int Daystomanufacture { get; set; }
        public string Productline { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public int? Productsubcategoryid { get; set; }
        public int? Productmodelid { get; set; }
        public DateTime Sellstartdate { get; set; }
        public DateTime? Sellenddate { get; set; }
        public DateTime? Discontinueddate { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime Modifieddate { get; set; }

        public virtual Productmodel Productmodel { get; set; }
        public virtual Productsubcategory Productsubcategory { get; set; }
        public virtual Unitmeasure SizeunitmeasurecodeNavigation { get; set; }
        public virtual Unitmeasure WeightunitmeasurecodeNavigation { get; set; }
        public virtual ICollection<Billofmaterial> BillofmaterialComponents { get; set; }
        public virtual ICollection<Billofmaterial> BillofmaterialProductassemblies { get; set; }
        public virtual ICollection<Productcosthistory> Productcosthistories { get; set; }
        public virtual ICollection<Productdocument> Productdocuments { get; set; }
        public virtual ICollection<Productinventory> Productinventories { get; set; }
        public virtual ICollection<Productlistpricehistory> Productlistpricehistories { get; set; }
        public virtual ICollection<Productproductphoto> Productproductphotos { get; set; }
        public virtual ICollection<Productreview> Productreviews { get; set; }
        public virtual ICollection<Transactionhistory> Transactionhistories { get; set; }
        public virtual ICollection<Workorder> Workorders { get; set; }
    }
}
