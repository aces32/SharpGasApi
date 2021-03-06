using Microsoft.EntityFrameworkCore.Migrations;

namespace SharpGasData.Migrations
{
    public partial class UpdateGasData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GasInformationGasId",
                table: "Vendors",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Availability",
                table: "GasInformation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GasImage",
                table: "GasInformation",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "GasInformation",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Availability",
                table: "GasInformation");

            migrationBuilder.DropColumn(
                name: "GasImage",
                table: "GasInformation");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "GasInformation");
        }
    }
}
