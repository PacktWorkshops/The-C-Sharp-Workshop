using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Chapter06.Examples.AdventureWorksProduction
{
    public partial class AdventureworksContext : DbContext
    {
        public AdventureworksContext()
        {
        }

        public AdventureworksContext(DbContextOptions<AdventureworksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Billofmaterial> Billofmaterials { get; set; }
        public virtual DbSet<Culture> Cultures { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Illustration> Illustrations { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Productcategory> Productcategories { get; set; }
        public virtual DbSet<Productcosthistory> Productcosthistories { get; set; }
        public virtual DbSet<Productdescription> Productdescriptions { get; set; }
        public virtual DbSet<Productdocument> Productdocuments { get; set; }
        public virtual DbSet<Productinventory> Productinventories { get; set; }
        public virtual DbSet<Productlistpricehistory> Productlistpricehistories { get; set; }
        public virtual DbSet<Productmodel> Productmodels { get; set; }
        public virtual DbSet<Productmodelillustration> Productmodelillustrations { get; set; }
        public virtual DbSet<Productmodelproductdescriptionculture> Productmodelproductdescriptioncultures { get; set; }
        public virtual DbSet<Productphoto> Productphotos { get; set; }
        public virtual DbSet<Productproductphoto> Productproductphotos { get; set; }
        public virtual DbSet<Productreview> Productreviews { get; set; }
        public virtual DbSet<Productsubcategory> Productsubcategories { get; set; }
        public virtual DbSet<Transactionhistory> Transactionhistories { get; set; }
        public virtual DbSet<Transactionhistoryarchive> Transactionhistoryarchives { get; set; }
        public virtual DbSet<Unitmeasure> Unitmeasures { get; set; }
        public virtual DbSet<Vproductanddescription> Vproductanddescriptions { get; set; }
        public virtual DbSet<Workorder> Workorders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Program.AdventureWorksConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("tablefunc")
                .HasPostgresExtension("uuid-ossp")
                .HasAnnotation("Relational:Collation", "Lithuanian_Lithuania.1252");

            modelBuilder.Entity<Billofmaterial>(entity =>
            {
                entity.HasKey(e => e.Billofmaterialsid)
                    .HasName("PK_BillOfMaterials_BillOfMaterialsID");

                entity.ToTable("billofmaterials", "production");

                entity.HasComment("Items required to make bicycles and bicycle subassemblies. It identifies the heirarchical relationship between a parent product and its components.");

                entity.Property(e => e.Billofmaterialsid)
                    .HasColumnName("billofmaterialsid")
                    .HasComment("Primary key for BillOfMaterials records.");

                entity.Property(e => e.Bomlevel)
                    .HasColumnName("bomlevel")
                    .HasComment("Indicates the depth the component is from its parent (AssemblyID).");

                entity.Property(e => e.Componentid)
                    .HasColumnName("componentid")
                    .HasComment("Component identification number. Foreign key to Product.ProductID.");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasComment("Date the component stopped being used in the assembly item.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Perassemblyqty)
                    .HasPrecision(8, 2)
                    .HasColumnName("perassemblyqty")
                    .HasDefaultValueSql("1.00")
                    .HasComment("Quantity of the component needed to create the assembly.");

                entity.Property(e => e.Productassemblyid)
                    .HasColumnName("productassemblyid")
                    .HasComment("Parent product identification number. Foreign key to Product.ProductID.");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasDefaultValueSql("now()")
                    .HasComment("Date the component started being used in the assembly item.");

                entity.Property(e => e.Unitmeasurecode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("unitmeasurecode")
                    .IsFixedLength(true)
                    .HasComment("Standard code identifying the unit of measure for the quantity.");

                entity.HasOne(d => d.Component)
                    .WithMany(p => p.BillofmaterialComponents)
                    .HasForeignKey(d => d.Componentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BillOfMaterials_Product_ComponentID");

                entity.HasOne(d => d.Productassembly)
                    .WithMany(p => p.BillofmaterialProductassemblies)
                    .HasForeignKey(d => d.Productassemblyid)
                    .HasConstraintName("FK_BillOfMaterials_Product_ProductAssemblyID");

                entity.HasOne(d => d.UnitmeasurecodeNavigation)
                    .WithMany(p => p.Billofmaterials)
                    .HasForeignKey(d => d.Unitmeasurecode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BillOfMaterials_UnitMeasure_UnitMeasureCode");
            });

            modelBuilder.Entity<Culture>(entity =>
            {
                entity.ToTable("culture", "production");

                entity.HasComment("Lookup table containing the languages in which some AdventureWorks data is stored.");

                entity.Property(e => e.Cultureid)
                    .HasMaxLength(6)
                    .HasColumnName("cultureid")
                    .IsFixedLength(true)
                    .HasComment("Primary key for Culture records.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasComment("Culture description.");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.Documentnode)
                    .HasName("PK_Document_DocumentNode");

                entity.ToTable("document", "production");

                entity.HasComment("Product maintenance documents.");

                entity.HasIndex(e => e.Rowguid, "document_rowguid_key")
                    .IsUnique();

                entity.Property(e => e.Documentnode)
                    .HasColumnType("character varying")
                    .HasColumnName("documentnode")
                    .HasDefaultValueSql("'/'::character varying")
                    .HasComment("Primary key for Document records.");

                entity.Property(e => e.Changenumber)
                    .HasColumnName("changenumber")
                    .HasComment("Engineering change approval number.");

                entity.Property(e => e.Document1)
                    .HasColumnName("document")
                    .HasComment("Complete document.");

                entity.Property(e => e.Documentsummary)
                    .HasColumnName("documentsummary")
                    .HasComment("Document abstract.");

                entity.Property(e => e.Fileextension)
                    .HasMaxLength(8)
                    .HasColumnName("fileextension")
                    .HasComment("File extension indicating the document type. For example, .doc or .txt.");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasColumnName("filename")
                    .HasComment("File name of the document");

                entity.Property(e => e.Folderflag)
                    .HasColumnName("folderflag")
                    .HasComment("0 = This is a folder, 1 = This is a document.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Owner)
                    .HasColumnName("owner")
                    .HasComment("Employee who controls the document.  Foreign key to Employee.BusinessEntityID");

                entity.Property(e => e.Revision)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("revision")
                    .IsFixedLength(true)
                    .HasComment("Revision number of the document.");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("uuid_generate_v1()")
                    .HasComment("ROWGUIDCOL number uniquely identifying the record. Required for FileStream.");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("1 = Pending approval, 2 = Approved, 3 = Obsolete");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("title")
                    .HasComment("Title of the document.");
            });

            modelBuilder.Entity<Illustration>(entity =>
            {
                entity.ToTable("illustration", "production");

                entity.HasComment("Bicycle assembly diagrams.");

                entity.Property(e => e.Illustrationid)
                    .HasColumnName("illustrationid")
                    .HasComment("Primary key for Illustration records.");

                entity.Property(e => e.Diagram)
                    .HasColumnType("xml")
                    .HasColumnName("diagram")
                    .HasComment("Illustrations used in manufacturing instructions. Stored as XML.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location", "production");

                entity.HasComment("Product inventory and manufacturing locations.");

                entity.Property(e => e.Locationid)
                    .HasColumnName("locationid")
                    .HasComment("Primary key for Location records.");

                entity.Property(e => e.Availability)
                    .HasPrecision(8, 2)
                    .HasColumnName("availability")
                    .HasDefaultValueSql("0.00")
                    .HasComment("Work capacity (in hours) of the manufacturing location.");

                entity.Property(e => e.Costrate)
                    .HasColumnName("costrate")
                    .HasDefaultValueSql("0.00")
                    .HasComment("Standard hourly cost of the manufacturing location.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasComment("Location description.");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product", "production");

                entity.HasComment("Products sold or used in the manfacturing of sold products.");

                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .HasComment("Primary key for Product records.");

                entity.Property(e => e.Class)
                    .HasMaxLength(2)
                    .HasColumnName("class")
                    .IsFixedLength(true)
                    .HasComment("H = High, M = Medium, L = Low");

                entity.Property(e => e.Color)
                    .HasMaxLength(15)
                    .HasColumnName("color")
                    .HasComment("Product color.");

                entity.Property(e => e.Daystomanufacture)
                    .HasColumnName("daystomanufacture")
                    .HasComment("Number of days required to manufacture the product.");

                entity.Property(e => e.Discontinueddate)
                    .HasColumnName("discontinueddate")
                    .HasComment("Date the product was discontinued.");

                entity.Property(e => e.Finishedgoodsflag)
                    .IsRequired()
                    .HasColumnName("finishedgoodsflag")
                    .HasDefaultValueSql("true")
                    .HasComment("0 = Product is not a salable item. 1 = Product is salable.");

                entity.Property(e => e.Listprice)
                    .HasColumnName("listprice")
                    .HasComment("Selling price.");

                entity.Property(e => e.Makeflag)
                    .IsRequired()
                    .HasColumnName("makeflag")
                    .HasDefaultValueSql("true")
                    .HasComment("0 = Product is purchased, 1 = Product is manufactured in-house.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasComment("Name of the product.");

                entity.Property(e => e.Productline)
                    .HasMaxLength(2)
                    .HasColumnName("productline")
                    .IsFixedLength(true)
                    .HasComment("R = Road, M = Mountain, T = Touring, S = Standard");

                entity.Property(e => e.Productmodelid)
                    .HasColumnName("productmodelid")
                    .HasComment("Product is a member of this product model. Foreign key to ProductModel.ProductModelID.");

                entity.Property(e => e.Productnumber)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("productnumber")
                    .HasComment("Unique product identification number.");

                entity.Property(e => e.Productsubcategoryid)
                    .HasColumnName("productsubcategoryid")
                    .HasComment("Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID.");

                entity.Property(e => e.Reorderpoint)
                    .HasColumnName("reorderpoint")
                    .HasComment("Inventory level that triggers a purchase order or work order.");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("uuid_generate_v1()");

                entity.Property(e => e.Safetystocklevel)
                    .HasColumnName("safetystocklevel")
                    .HasComment("Minimum inventory quantity.");

                entity.Property(e => e.Sellenddate)
                    .HasColumnName("sellenddate")
                    .HasComment("Date the product was no longer available for sale.");

                entity.Property(e => e.Sellstartdate)
                    .HasColumnName("sellstartdate")
                    .HasComment("Date the product was available for sale.");

                entity.Property(e => e.Size)
                    .HasMaxLength(5)
                    .HasColumnName("size")
                    .HasComment("Product size.");

                entity.Property(e => e.Sizeunitmeasurecode)
                    .HasMaxLength(3)
                    .HasColumnName("sizeunitmeasurecode")
                    .IsFixedLength(true)
                    .HasComment("Unit of measure for Size column.");

                entity.Property(e => e.Standardcost)
                    .HasColumnName("standardcost")
                    .HasComment("Standard cost of the product.");

                entity.Property(e => e.Style)
                    .HasMaxLength(2)
                    .HasColumnName("style")
                    .IsFixedLength(true)
                    .HasComment("W = Womens, M = Mens, U = Universal");

                entity.Property(e => e.Weight)
                    .HasPrecision(8, 2)
                    .HasColumnName("weight")
                    .HasComment("Product weight.");

                entity.Property(e => e.Weightunitmeasurecode)
                    .HasMaxLength(3)
                    .HasColumnName("weightunitmeasurecode")
                    .IsFixedLength(true)
                    .HasComment("Unit of measure for Weight column.");

                entity.HasOne(d => d.Productmodel)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Productmodelid)
                    .HasConstraintName("FK_Product_ProductModel_ProductModelID");

                entity.HasOne(d => d.Productsubcategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Productsubcategoryid)
                    .HasConstraintName("FK_Product_ProductSubcategory_ProductSubcategoryID");

                entity.HasOne(d => d.SizeunitmeasurecodeNavigation)
                    .WithMany(p => p.ProductSizeunitmeasurecodeNavigations)
                    .HasForeignKey(d => d.Sizeunitmeasurecode)
                    .HasConstraintName("FK_Product_UnitMeasure_SizeUnitMeasureCode");

                entity.HasOne(d => d.WeightunitmeasurecodeNavigation)
                    .WithMany(p => p.ProductWeightunitmeasurecodeNavigations)
                    .HasForeignKey(d => d.Weightunitmeasurecode)
                    .HasConstraintName("FK_Product_UnitMeasure_WeightUnitMeasureCode");
            });

            modelBuilder.Entity<Productcategory>(entity =>
            {
                entity.ToTable("productcategory", "production");

                entity.HasComment("High-level product categorization.");

                entity.Property(e => e.Productcategoryid)
                    .HasColumnName("productcategoryid")
                    .HasComment("Primary key for ProductCategory records.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasComment("Category description.");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("uuid_generate_v1()");
            });

            modelBuilder.Entity<Productcosthistory>(entity =>
            {
                entity.HasKey(e => new { e.Productid, e.Startdate })
                    .HasName("PK_ProductCostHistory_ProductID_StartDate");

                entity.ToTable("productcosthistory", "production");

                entity.HasComment("Changes in the cost of a product over time.");

                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .HasComment("Product identification number. Foreign key to Product.ProductID");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasComment("Product cost start date.");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasComment("Product cost end date.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Standardcost)
                    .HasColumnName("standardcost")
                    .HasComment("Standard cost of the product.");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productcosthistories)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCostHistory_Product_ProductID");
            });

            modelBuilder.Entity<Productdescription>(entity =>
            {
                entity.ToTable("productdescription", "production");

                entity.HasComment("Product descriptions in several languages.");

                entity.Property(e => e.Productdescriptionid)
                    .HasColumnName("productdescriptionid")
                    .HasComment("Primary key for ProductDescription records.");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasColumnName("description")
                    .HasComment("Description of the product.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("uuid_generate_v1()");
            });

            modelBuilder.Entity<Productdocument>(entity =>
            {
                entity.HasKey(e => new { e.Productid, e.Documentnode })
                    .HasName("PK_ProductDocument_ProductID_DocumentNode");

                entity.ToTable("productdocument", "production");

                entity.HasComment("Cross-reference table mapping products to related product documents.");

                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .HasComment("Product identification number. Foreign key to Product.ProductID.");

                entity.Property(e => e.Documentnode)
                    .HasColumnType("character varying")
                    .HasColumnName("documentnode")
                    .HasDefaultValueSql("'/'::character varying")
                    .HasComment("Document identification number. Foreign key to Document.DocumentNode.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.DocumentnodeNavigation)
                    .WithMany(p => p.Productdocuments)
                    .HasForeignKey(d => d.Documentnode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductDocument_Document_DocumentNode");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productdocuments)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductDocument_Product_ProductID");
            });

            modelBuilder.Entity<Productinventory>(entity =>
            {
                entity.HasKey(e => new { e.Productid, e.Locationid })
                    .HasName("PK_ProductInventory_ProductID_LocationID");

                entity.ToTable("productinventory", "production");

                entity.HasComment("Product inventory information.");

                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .HasComment("Product identification number. Foreign key to Product.ProductID.");

                entity.Property(e => e.Locationid)
                    .HasColumnName("locationid")
                    .HasComment("Inventory location identification number. Foreign key to Location.LocationID.");

                entity.Property(e => e.Bin)
                    .HasColumnName("bin")
                    .HasComment("Storage container on a shelf in an inventory location.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasComment("Quantity of products in the inventory location.");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("uuid_generate_v1()");

                entity.Property(e => e.Shelf)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("shelf")
                    .HasComment("Storage compartment within an inventory location.");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Productinventories)
                    .HasForeignKey(d => d.Locationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductInventory_Location_LocationID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productinventories)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductInventory_Product_ProductID");
            });

            modelBuilder.Entity<Productlistpricehistory>(entity =>
            {
                entity.HasKey(e => new { e.Productid, e.Startdate })
                    .HasName("PK_ProductListPriceHistory_ProductID_StartDate");

                entity.ToTable("productlistpricehistory", "production");

                entity.HasComment("Changes in the list price of a product over time.");

                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .HasComment("Product identification number. Foreign key to Product.ProductID");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasComment("List price start date.");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasComment("List price end date");

                entity.Property(e => e.Listprice)
                    .HasColumnName("listprice")
                    .HasComment("Product list price.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productlistpricehistories)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductListPriceHistory_Product_ProductID");
            });

            modelBuilder.Entity<Productmodel>(entity =>
            {
                entity.ToTable("productmodel", "production");

                entity.HasComment("Product model classification.");

                entity.Property(e => e.Productmodelid)
                    .HasColumnName("productmodelid")
                    .HasComment("Primary key for ProductModel records.");

                entity.Property(e => e.Catalogdescription)
                    .HasColumnType("xml")
                    .HasColumnName("catalogdescription")
                    .HasComment("Detailed product catalog information in xml format.");

                entity.Property(e => e.Instructions)
                    .HasColumnType("xml")
                    .HasColumnName("instructions")
                    .HasComment("Manufacturing instructions in xml format.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasComment("Product model description.");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("uuid_generate_v1()");
            });

            modelBuilder.Entity<Productmodelillustration>(entity =>
            {
                entity.HasKey(e => new { e.Productmodelid, e.Illustrationid })
                    .HasName("PK_ProductModelIllustration_ProductModelID_IllustrationID");

                entity.ToTable("productmodelillustration", "production");

                entity.HasComment("Cross-reference table mapping product models and illustrations.");

                entity.Property(e => e.Productmodelid)
                    .HasColumnName("productmodelid")
                    .HasComment("Primary key. Foreign key to ProductModel.ProductModelID.");

                entity.Property(e => e.Illustrationid)
                    .HasColumnName("illustrationid")
                    .HasComment("Primary key. Foreign key to Illustration.IllustrationID.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.Illustration)
                    .WithMany(p => p.Productmodelillustrations)
                    .HasForeignKey(d => d.Illustrationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductModelIllustration_Illustration_IllustrationID");

                entity.HasOne(d => d.Productmodel)
                    .WithMany(p => p.Productmodelillustrations)
                    .HasForeignKey(d => d.Productmodelid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductModelIllustration_ProductModel_ProductModelID");
            });

            modelBuilder.Entity<Productmodelproductdescriptionculture>(entity =>
            {
                entity.HasKey(e => new { e.Productmodelid, e.Productdescriptionid, e.Cultureid })
                    .HasName("PK_ProductModelProductDescriptionCulture_ProductModelID_Product");

                entity.ToTable("productmodelproductdescriptionculture", "production");

                entity.HasComment("Cross-reference table mapping product descriptions and the language the description is written in.");

                entity.Property(e => e.Productmodelid)
                    .HasColumnName("productmodelid")
                    .HasComment("Primary key. Foreign key to ProductModel.ProductModelID.");

                entity.Property(e => e.Productdescriptionid)
                    .HasColumnName("productdescriptionid")
                    .HasComment("Primary key. Foreign key to ProductDescription.ProductDescriptionID.");

                entity.Property(e => e.Cultureid)
                    .HasMaxLength(6)
                    .HasColumnName("cultureid")
                    .IsFixedLength(true)
                    .HasComment("Culture identification number. Foreign key to Culture.CultureID.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.Productmodelproductdescriptioncultures)
                    .HasForeignKey(d => d.Cultureid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductModelProductDescriptionCulture_Culture_CultureID");

                entity.HasOne(d => d.Productdescription)
                    .WithMany(p => p.Productmodelproductdescriptioncultures)
                    .HasForeignKey(d => d.Productdescriptionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductModelProductDescriptionCulture_ProductDescription_Pro");

                entity.HasOne(d => d.Productmodel)
                    .WithMany(p => p.Productmodelproductdescriptioncultures)
                    .HasForeignKey(d => d.Productmodelid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductModelProductDescriptionCulture_ProductModel_ProductMo");
            });

            modelBuilder.Entity<Productphoto>(entity =>
            {
                entity.ToTable("productphoto", "production");

                entity.HasComment("Product images.");

                entity.Property(e => e.Productphotoid)
                    .HasColumnName("productphotoid")
                    .HasComment("Primary key for ProductPhoto records.");

                entity.Property(e => e.Largephoto)
                    .HasColumnName("largephoto")
                    .HasComment("Large image of the product.");

                entity.Property(e => e.Largephotofilename)
                    .HasMaxLength(50)
                    .HasColumnName("largephotofilename")
                    .HasComment("Large image file name.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Thumbnailphoto)
                    .HasColumnName("thumbnailphoto")
                    .HasComment("Small image of the product.");

                entity.Property(e => e.Thumbnailphotofilename)
                    .HasMaxLength(50)
                    .HasColumnName("thumbnailphotofilename")
                    .HasComment("Small image file name.");
            });

            modelBuilder.Entity<Productproductphoto>(entity =>
            {
                entity.HasKey(e => new { e.Productid, e.Productphotoid })
                    .HasName("PK_ProductProductPhoto_ProductID_ProductPhotoID");

                entity.ToTable("productproductphoto", "production");

                entity.HasComment("Cross-reference table mapping products and product photos.");

                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .HasComment("Product identification number. Foreign key to Product.ProductID.");

                entity.Property(e => e.Productphotoid)
                    .HasColumnName("productphotoid")
                    .HasComment("Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Primary)
                    .HasColumnName("primary")
                    .HasComment("0 = Photo is not the principal image. 1 = Photo is the principal image.");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productproductphotos)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductProductPhoto_Product_ProductID");

                entity.HasOne(d => d.Productphoto)
                    .WithMany(p => p.Productproductphotos)
                    .HasForeignKey(d => d.Productphotoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductProductPhoto_ProductPhoto_ProductPhotoID");
            });

            modelBuilder.Entity<Productreview>(entity =>
            {
                entity.ToTable("productreview", "production");

                entity.HasComment("Customer reviews of products they have purchased.");

                entity.Property(e => e.Productreviewid)
                    .HasColumnName("productreviewid")
                    .HasComment("Primary key for ProductReview records.");

                entity.Property(e => e.Comments)
                    .HasMaxLength(3850)
                    .HasColumnName("comments")
                    .HasComment("Reviewer's comments");

                entity.Property(e => e.Emailaddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("emailaddress")
                    .HasComment("Reviewer's e-mail address.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .HasComment("Product identification number. Foreign key to Product.ProductID.");

                entity.Property(e => e.Rating)
                    .HasColumnName("rating")
                    .HasComment("Product rating given by the reviewer. Scale is 1 to 5 with 5 as the highest rating.");

                entity.Property(e => e.Reviewdate)
                    .HasColumnName("reviewdate")
                    .HasDefaultValueSql("now()")
                    .HasComment("Date review was submitted.");

                entity.Property(e => e.Reviewername)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("reviewername")
                    .HasComment("Name of the reviewer.");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productreviews)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductReview_Product_ProductID");
            });

            modelBuilder.Entity<Productsubcategory>(entity =>
            {
                entity.ToTable("productsubcategory", "production");

                entity.HasComment("Product subcategories. See ProductCategory table.");

                entity.Property(e => e.Productsubcategoryid)
                    .HasColumnName("productsubcategoryid")
                    .HasComment("Primary key for ProductSubcategory records.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasComment("Subcategory description.");

                entity.Property(e => e.Productcategoryid)
                    .HasColumnName("productcategoryid")
                    .HasComment("Product category identification number. Foreign key to ProductCategory.ProductCategoryID.");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("uuid_generate_v1()");

                entity.HasOne(d => d.Productcategory)
                    .WithMany(p => p.Productsubcategories)
                    .HasForeignKey(d => d.Productcategoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductSubcategory_ProductCategory_ProductCategoryID");
            });

            modelBuilder.Entity<Transactionhistory>(entity =>
            {
                entity.HasKey(e => e.Transactionid)
                    .HasName("PK_TransactionHistory_TransactionID");

                entity.ToTable("transactionhistory", "production");

                entity.HasComment("Record of each purchase order, sales order, or work order transaction year to date.");

                entity.Property(e => e.Transactionid)
                    .HasColumnName("transactionid")
                    .HasComment("Primary key for TransactionHistory records.");

                entity.Property(e => e.Actualcost)
                    .HasColumnName("actualcost")
                    .HasComment("Product cost.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .HasComment("Product identification number. Foreign key to Product.ProductID.");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasComment("Product quantity.");

                entity.Property(e => e.Referenceorderid)
                    .HasColumnName("referenceorderid")
                    .HasComment("Purchase order, sales order, or work order identification number.");

                entity.Property(e => e.Referenceorderlineid)
                    .HasColumnName("referenceorderlineid")
                    .HasComment("Line number associated with the purchase order, sales order, or work order.");

                entity.Property(e => e.Transactiondate)
                    .HasColumnName("transactiondate")
                    .HasDefaultValueSql("now()")
                    .HasComment("Date and time of the transaction.");

                entity.Property(e => e.Transactiontype)
                    .HasMaxLength(1)
                    .HasColumnName("transactiontype")
                    .HasComment("W = WorkOrder, S = SalesOrder, P = PurchaseOrder");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Transactionhistories)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransactionHistory_Product_ProductID");
            });

            modelBuilder.Entity<Transactionhistoryarchive>(entity =>
            {
                entity.HasKey(e => e.Transactionid)
                    .HasName("PK_TransactionHistoryArchive_TransactionID");

                entity.ToTable("transactionhistoryarchive", "production");

                entity.HasComment("Transactions for previous years.");

                entity.Property(e => e.Transactionid)
                    .ValueGeneratedNever()
                    .HasColumnName("transactionid")
                    .HasComment("Primary key for TransactionHistoryArchive records.");

                entity.Property(e => e.Actualcost)
                    .HasColumnName("actualcost")
                    .HasComment("Product cost.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .HasComment("Product identification number. Foreign key to Product.ProductID.");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasComment("Product quantity.");

                entity.Property(e => e.Referenceorderid)
                    .HasColumnName("referenceorderid")
                    .HasComment("Purchase order, sales order, or work order identification number.");

                entity.Property(e => e.Referenceorderlineid)
                    .HasColumnName("referenceorderlineid")
                    .HasComment("Line number associated with the purchase order, sales order, or work order.");

                entity.Property(e => e.Transactiondate)
                    .HasColumnName("transactiondate")
                    .HasDefaultValueSql("now()")
                    .HasComment("Date and time of the transaction.");

                entity.Property(e => e.Transactiontype)
                    .HasMaxLength(1)
                    .HasColumnName("transactiontype")
                    .HasComment("W = Work Order, S = Sales Order, P = Purchase Order");
            });

            modelBuilder.Entity<Unitmeasure>(entity =>
            {
                entity.HasKey(e => e.Unitmeasurecode)
                    .HasName("PK_UnitMeasure_UnitMeasureCode");

                entity.ToTable("unitmeasure", "production");

                entity.HasComment("Unit of measure lookup table.");

                entity.Property(e => e.Unitmeasurecode)
                    .HasMaxLength(3)
                    .HasColumnName("unitmeasurecode")
                    .IsFixedLength(true)
                    .HasComment("Primary key.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasComment("Unit of measure description.");
            });

            modelBuilder.Entity<Vproductanddescription>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vproductanddescription", "production");

                entity.Property(e => e.Cultureid)
                    .HasMaxLength(6)
                    .HasColumnName("cultureid")
                    .IsFixedLength(true);

                entity.Property(e => e.Description)
                    .HasMaxLength(400)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Productmodel)
                    .HasMaxLength(50)
                    .HasColumnName("productmodel");
            });

            modelBuilder.Entity<Workorder>(entity =>
            {
                entity.ToTable("workorder", "production");

                entity.HasComment("Manufacturing work orders.");

                entity.Property(e => e.Workorderid)
                    .HasColumnName("workorderid")
                    .HasComment("Primary key for WorkOrder records.");

                entity.Property(e => e.Duedate)
                    .HasColumnName("duedate")
                    .HasComment("Work order due date.");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasComment("Work order end date.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Orderqty)
                    .HasColumnName("orderqty")
                    .HasComment("Product quantity to build.");

                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .HasComment("Product identification number. Foreign key to Product.ProductID.");

                entity.Property(e => e.Scrappedqty)
                    .HasColumnName("scrappedqty")
                    .HasComment("Quantity that failed inspection.");

                entity.Property(e => e.Scrapreasonid)
                    .HasColumnName("scrapreasonid")
                    .HasComment("Reason for inspection failure.");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasComment("Work order start date.");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Workorders)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkOrder_Product_ProductID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
