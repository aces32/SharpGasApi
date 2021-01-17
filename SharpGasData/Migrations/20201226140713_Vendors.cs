using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SharpGasData.Migrations
{
    public partial class Vendors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(nullable: true),
                    VendorAddress = table.Column<string>(nullable: true),
                    VendorCountry = table.Column<string>(nullable: true),
                    VendorState = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    VendorLGA = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    VendorEmail = table.Column<string>(nullable: true),
                    VendorMobileNo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    VendorPassword = table.Column<byte[]>(nullable: true),
                    VendorType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
