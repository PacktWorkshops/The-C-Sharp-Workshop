using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Chapter06.Activities.Activity02
{
    public partial class GlobalFactory2020Context : DbContext
    {
        public GlobalFactory2020Context()
        {
        }

        public GlobalFactory2020Context(DbContextOptions<GlobalFactory2020Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Not needed for the activity- just to enable lazy loading.
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(Program.ConnectionString);
            }

            // Not needed for the activity- just to enable logging of SQL
            optionsBuilder.LogTo((s) => Debug.WriteLine(s));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("Manufacturer", "Factory");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                //entity.Property(e => e.FoundedAt)
                //    .HasColumnType("date");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "Factory");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_Product_Manufacturer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
