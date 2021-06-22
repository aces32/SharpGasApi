using Microsoft.EntityFrameworkCore.Migrations;

namespace SharpGasData.Migrations
{
    public partial class CustomerOrderMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerGasMap");

            migrationBuilder.CreateTable(
                name: "CustomerOrders",
                columns: table => new
                {
                    CustomerOrdersID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    GasId = table.Column<int>(nullable: false),
                    VendorsVendorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrders", x => x.CustomerOrdersID);
                    table.ForeignKey(
                        name: "FK_CustomerOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerOrders_GasInformation_GasId",
                        column: x => x.GasId,
                        principalTable: "GasInformation",
                        principalColumn: "GasID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerOrders_Vendors_VendorsVendorID",
                        column: x => x.VendorsVendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VendorGasMap",
                columns: table => new
                {
                    VendorGasMapID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorID = table.Column<int>(nullable: false),
                    GasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorGasMap", x => x.VendorGasMapID);
                    table.ForeignKey(
                        name: "FK_VendorGasMap_GasInformation_GasId",
                        column: x => x.GasId,
                        principalTable: "GasInformation",
                        principalColumn: "GasID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendorGasMap_Vendors_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_CustomerId",
                table: "CustomerOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_GasId",
                table: "CustomerOrders",
                column: "GasId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_VendorsVendorID",
                table: "CustomerOrders",
                column: "VendorsVendorID");

            migrationBuilder.CreateIndex(
                name: "IX_VendorGasMap_GasId",
                table: "VendorGasMap",
                column: "GasId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorGasMap_VendorID",
                table: "VendorGasMap",
                column: "VendorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrders");

            migrationBuilder.DropTable(
                name: "VendorGasMap");

            migrationBuilder.CreateTable(
                name: "CustomerGasMap",
                columns: table => new
                {
                    CustomerGasMapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    GasId = table.Column<int>(type: "int", nullable: false),
                    VendorsVendorID = table.Column<int>(type: "int", nullable: true)
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
        }
    }
}
