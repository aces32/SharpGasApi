﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SharpGasData.Models;

namespace SharpGasData.Migrations
{
    [DbContext(typeof(SharpGasContext))]
    [Migration("20210620205324_UpdateRelationShip")]
    partial class UpdateRelationShip
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SharpGasData.Entites.Customers", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CustomerID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .HasColumnName("Address 1")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("Address2")
                        .HasColumnName("Address 2")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("Country")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("MobileNumber")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("Username")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SharpGasData.Entites.GasInformation", b =>
                {
                    b.Property<int>("GasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("GasID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Availability")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomersCustomerId")
                        .HasColumnType("int");

                    b.Property<string>("GasImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GasMobileNumber")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<double?>("GasWeight")
                        .HasColumnType("float");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<int>("VendorID")
                        .HasColumnType("int");

                    b.Property<int?>("VendorsVendorID")
                        .HasColumnType("int");

                    b.HasKey("GasId");

                    b.HasIndex("CustomersCustomerId");

                    b.HasIndex("VendorsVendorID");

                    b.ToTable("GasInformation");
                });

            modelBuilder.Entity("SharpGasData.Entities.AuthCredentials", b =>
                {
                    b.Property<int>("AuthID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AuthID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Roles")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("expiryLength")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthID");

                    b.ToTable("AuthCredentials");
                });

            modelBuilder.Entity("SharpGasData.Entities.EncryptionKeys", b =>
                {
                    b.Property<int>("KeyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PrivateKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrivateKeyXML")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicKeyXML")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KeyId");

                    b.ToTable("EncryptionKeys");
                });

            modelBuilder.Entity("SharpGasData.Entities.Vendors", b =>
                {
                    b.Property<int>("VendorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VendorID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VendorAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorLGA")
                        .HasColumnName("VendorLGA")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("VendorMobileNo")
                        .HasColumnName("VendorMobileNo")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("VendorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("VendorPassword")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("VendorState")
                        .HasColumnName("VendorState")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("VendorType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VendorID");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("SharpGasData.Entites.GasInformation", b =>
                {
                    b.HasOne("SharpGasData.Entites.Customers", "Customers")
                        .WithMany("GasInformation")
                        .HasForeignKey("CustomersCustomerId");

                    b.HasOne("SharpGasData.Entities.Vendors", "Vendors")
                        .WithMany("GasInformation")
                        .HasForeignKey("VendorsVendorID");
                });
#pragma warning restore 612, 618
        }
    }
}
