using Microsoft.EntityFrameworkCore.Migrations;

namespace SharpGasData.Migrations
{
    public partial class GasTableCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "GasInformation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "GasInformation",
                type: "int",
                nullable: true);
        }
    }
}
