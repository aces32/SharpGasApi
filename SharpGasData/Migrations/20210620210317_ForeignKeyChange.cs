using Microsoft.EntityFrameworkCore.Migrations;

namespace SharpGasData.Migrations
{
    public partial class ForeignKeyChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_GasInformation_Customers_CustomersCustomerId",
            //    table: "GasInformation");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_GasInformation_Vendors_VendorsVendorID",
            //    table: "GasInformation");

            //migrationBuilder.DropIndex(
            //    name: "IX_GasInformation_CustomersCustomerId",
            //    table: "GasInformation");

            //migrationBuilder.DropIndex(
            //    name: "IX_GasInformation_VendorsVendorID",
            //    table: "GasInformation");

            //migrationBuilder.DropColumn(
            //    name: "CustomersCustomerId",
            //    table: "GasInformation");

            //migrationBuilder.DropColumn(
            //    name: "VendorsVendorID",
            //    table: "GasInformation");

            migrationBuilder.CreateIndex(
                name: "IX_GasInformation_CustomerId",
                table: "GasInformation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GasInformation_VendorID",
                table: "GasInformation",
                column: "VendorID");

            migrationBuilder.AddForeignKey(
                name: "FK_GasInformation_Customers_CustomerId",
                table: "GasInformation",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GasInformation_Vendors_VendorID",
                table: "GasInformation",
                column: "VendorID",
                principalTable: "Vendors",
                principalColumn: "VendorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_GasInformation_Customers_CustomerId",
            //    table: "GasInformation");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_GasInformation_Vendors_VendorID",
            //    table: "GasInformation");

            //migrationBuilder.DropIndex(
            //    name: "IX_GasInformation_CustomerId",
            //    table: "GasInformation");

            //migrationBuilder.DropIndex(
            //    name: "IX_GasInformation_VendorID",
            //    table: "GasInformation");

            //migrationBuilder.AddColumn<int>(
            //    name: "CustomersCustomerId",
            //    table: "GasInformation",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "VendorsVendorID",
            //    table: "GasInformation",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_GasInformation_CustomersCustomerId",
            //    table: "GasInformation",
            //    column: "CustomersCustomerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_GasInformation_VendorsVendorID",
            //    table: "GasInformation",
            //    column: "VendorsVendorID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_GasInformation_Customers_CustomersCustomerId",
            //    table: "GasInformation",
            //    column: "CustomersCustomerId",
            //    principalTable: "Customers",
            //    principalColumn: "CustomerID",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_GasInformation_Vendors_VendorsVendorID",
            //    table: "GasInformation",
            //    column: "VendorsVendorID",
            //    principalTable: "Vendors",
            //    principalColumn: "VendorID",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
