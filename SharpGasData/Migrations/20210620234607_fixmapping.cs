using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SharpGasData.Migrations
{
    public partial class fixmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GasInformation_Customers_CustomersCustomerId",
                table: "GasInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_GasInformation_Vendors_VendorsVendorID",
                table: "GasInformation");

            migrationBuilder.DropIndex(
                name: "IX_GasInformation_CustomersCustomerId",
                table: "GasInformation");

            migrationBuilder.DropIndex(
                name: "IX_GasInformation_VendorsVendorID",
                table: "GasInformation");

            migrationBuilder.DropColumn(
                name: "CustomersCustomerId",
                table: "GasInformation");

            migrationBuilder.DropColumn(
                name: "VendorsVendorID",
                table: "GasInformation");

 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomersCustomerId",
                table: "GasInformation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorsVendorID",
                table: "GasInformation",
                type: "int",
                nullable: true);


            migrationBuilder.CreateIndex(
                name: "IX_GasInformation_CustomersCustomerId",
                table: "GasInformation",
                column: "CustomersCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GasInformation_VendorsVendorID",
                table: "GasInformation",
                column: "VendorsVendorID");

            migrationBuilder.AddForeignKey(
                name: "FK_GasInformation_Customers_CustomersCustomerId",
                table: "GasInformation",
                column: "CustomersCustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GasInformation_Vendors_VendorsVendorID",
                table: "GasInformation",
                column: "VendorsVendorID",
                principalTable: "Vendors",
                principalColumn: "VendorID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
