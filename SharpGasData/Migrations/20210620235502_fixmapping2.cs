using Microsoft.EntityFrameworkCore.Migrations;

namespace SharpGasData.Migrations
{
    public partial class fixmapping2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrders_Vendors_VendorsVendorID",
                table: "CustomerOrders");

            migrationBuilder.DropIndex(
                name: "IX_CustomerOrders_VendorsVendorID",
                table: "CustomerOrders");

            migrationBuilder.DropColumn(
                name: "VendorsVendorID",
                table: "CustomerOrders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VendorsVendorID",
                table: "CustomerOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_VendorsVendorID",
                table: "CustomerOrders",
                column: "VendorsVendorID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrders_Vendors_VendorsVendorID",
                table: "CustomerOrders",
                column: "VendorsVendorID",
                principalTable: "Vendors",
                principalColumn: "VendorID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
