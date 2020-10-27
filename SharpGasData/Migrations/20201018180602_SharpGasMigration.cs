using Microsoft.EntityFrameworkCore.Migrations;

namespace SharpGasData.Migrations
{
    public partial class SharpGasMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterTable(
            //    name: "Customers",
            //    columns: table => new
            //    {
            //        CustomerID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FirstName = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
            //        LastName = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
            //        Username = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        MobileNumber = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
            //        EmailAddress = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
            //        Country = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
            //        Address1 = table.Column<string>(name: "Address 1", unicode: false, maxLength: 150, nullable: true),
            //        Address2 = table.Column<string>(name: "Address 2", unicode: false, maxLength: 150, nullable: true),
            //        Password = table.Column<string>(unicode: false, maxLength: 150, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Customers", x => x.CustomerID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "GasInformation",
            //    columns: table => new
            //    {
            //        GasID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        GasMobileNumber = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        CustomerId = table.Column<int>(nullable: true),
            //        GasWeight = table.Column<double>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_GasInformation", x => x.GasID);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "GasInformation");
        }
    }
}
