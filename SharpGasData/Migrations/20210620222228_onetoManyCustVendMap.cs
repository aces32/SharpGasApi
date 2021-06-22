using Microsoft.EntityFrameworkCore.Migrations;

namespace SharpGasData.Migrations
{
    public partial class onetoManyCustVendMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GasInformation_Customers_CustomerId",
                table: "GasInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_GasInformation_Vendors_VendorID",
                table: "GasInformation");

            migrationBuilder.DropIndex(
                name: "IX_GasInformation_CustomerId",
                table: "GasInformation");

            migrationBuilder.DropIndex(
                name: "IX_GasInformation_VendorID",
                table: "GasInformation");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "GasInformation");

            migrationBuilder.DropColumn(
                name: "VendorID",
                table: "GasInformation");

            migrationBuilder.AddColumn<int>(
                name: "CustomersCustomerId",
                table: "GasInformation",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorsVendorID",
                table: "GasInformation",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerGasMap",
                columns: table => new
                {
                    CustomerGasMapID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    GasId = table.Column<int>(nullable: false),
                    VendorsVendorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGasMap", x => x.CustomerGasMapID);
                    table.ForeignKey(
                        name: "FK_CustomerGasMap_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerGasMap_GasInformation_GasId",
                        column: x => x.GasId,
                        principalTable: "GasInformation",
                        principalColumn: "GasID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerGasMap_Vendors_VendorsVendorID",
                        column: x => x.VendorsVendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GasInformation_CustomersCustomerId",
                table: "GasInformation",
                column: "CustomersCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GasInformation_VendorsVendorID",
                table: "GasInformation",
                column: "VendorsVendorID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGasMap_CustomerId",
                table: "CustomerGasMap",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGasMap_GasId",
                table: "CustomerGasMap",
                column: "GasId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGasMap_VendorsVendorID",
                table: "CustomerGasMap",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GasInformation_Customers_CustomersCustomerId",
                table: "GasInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_GasInformation_Vendors_VendorsVendorID",
                table: "GasInformation");

            migrationBuilder.DropTable(
                name: "CustomerGasMap");

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

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "GasInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VendorID",
                table: "GasInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
