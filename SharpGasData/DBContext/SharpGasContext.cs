using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SharpGasData.Entites;
using SharpGasData.Entities;

namespace SharpGasData.Models
{
    public partial class SharpGasContext : DbContext
    {
        //public SharpGasContext()
        //{
        //}

        public SharpGasContext(DbContextOptions<SharpGasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<GasInformation> GasInformation { get; set; }
        public virtual DbSet<EncryptionKeys> EncryptionKeys { get; set; }
        public virtual DbSet<AuthCredentials> AuthCredentials { get; set; }
        public virtual DbSet<Vendors> Vendors { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=SharpGas.mssql.somee.com;Initial Catalog=SharpGas;User ID=Aces32_SQLLogin_1;Password=y376icyh7q");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Address1)
                    .HasColumnName("Address 1")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasColumnName("Address 2")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GasInformation>(entity =>
            {
                entity.HasKey(e => e.GasId);

                entity.Property(e => e.GasId).HasColumnName("GasID");

                entity.Property(e => e.GasMobileNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AuthCredentials>(entity =>
            {
                entity.HasKey(e => e.AuthID);

                entity.Property(e => e.AuthID).HasColumnName("AuthID");

            });

            modelBuilder.Entity<Vendors>(entity =>
            {
                entity.HasKey(e => e.VendorID);

                entity.Property(e => e.VendorID).HasColumnName("VendorID");
                entity.Property(e => e.VendorMobileNo).HasColumnName("VendorMobileNo")
                .HasMaxLength(50)
                .IsUnicode(false);
                entity.Property(e => e.VendorState).HasColumnName("VendorState")
                .HasMaxLength(150)
                .IsUnicode(false);
                entity.Property(e => e.VendorLGA).HasColumnName("VendorLGA")
                .HasMaxLength(150)
                .IsUnicode(false);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
