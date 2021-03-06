using Microsoft.EntityFrameworkCore.Migrations;

namespace SharpGasData.Migrations
{
    public partial class TieGastoCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomersCustomerId",
                table: "GasInformation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GasInformation_CustomersCustomerId",
                table: "GasInformation",
                column: "CustomersCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GasInformation_Customers_CustomersCustomerId",
                table: "GasInformation",
                column: "CustomersCustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GasInformation_Customers_CustomersCustomerId",
                table: "GasInformation");

            migrationBuilder.DropIndex(
                name: "IX_GasInformation_CustomersCustomerId",
                table: "GasInformation");

            migrationBuilder.DropColumn(
                name: "CustomersCustomerId",
                table: "GasInformation");
        }
    }
}
