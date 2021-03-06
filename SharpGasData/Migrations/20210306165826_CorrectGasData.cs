using Microsoft.EntityFrameworkCore.Migrations;

namespace SharpGasData.Migrations
{
    public partial class CorrectGasData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_GasInformation_GasInformationGasId",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_GasInformationGasId",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "GasInformationGasId",
                table: "Vendors");

            migrationBuilder.AddColumn<int>(
                name: "VendorsVendorID",
                table: "GasInformation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GasInformation_VendorsVendorID",
                table: "GasInformation",
                column: "VendorsVendorID");

            migrationBuilder.AddForeignKey(
                name: "FK_GasInformation_Vendors_VendorsVendorID",
                table: "GasInformation",
                column: "VendorsVendorID",
                principalTable: "Vendors",
                principalColumn: "VendorID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GasInformation_Vendors_VendorsVendorID",
                table: "GasInformation");

            migrationBuilder.DropIndex(
                name: "IX_GasInformation_VendorsVendorID",
                table: "GasInformation");

            migrationBuilder.DropColumn(
                name: "VendorsVendorID",
                table: "GasInformation");

            migrationBuilder.AddColumn<int>(
                name: "GasInformationGasId",
                table: "Vendors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_GasInformationGasId",
                table: "Vendors",
                column: "GasInformationGasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_GasInformation_GasInformationGasId",
                table: "Vendors",
                column: "GasInformationGasId",
                principalTable: "GasInformation",
                principalColumn: "GasID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
