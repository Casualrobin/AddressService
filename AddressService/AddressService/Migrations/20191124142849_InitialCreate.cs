using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    AggregateCity = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "ID", "AggregateCity", "City", "Country", "FirstName", "LastName", "StreetAddress" },
                values: new object[] { 1, "london", "London", "England", "John", "Smith", "Test St 1" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "ID", "AggregateCity", "City", "Country", "FirstName", "LastName", "StreetAddress" },
                values: new object[] { 2, "london", "London", "England", "Jane", "Doe", "Test St 2" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "ID", "AggregateCity", "City", "Country", "FirstName", "LastName", "StreetAddress" },
                values: new object[] { 3, "newyork", "New York", "USA", "Tim", "Jones", "Test St 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
