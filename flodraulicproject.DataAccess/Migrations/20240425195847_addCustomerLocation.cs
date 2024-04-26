using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace flodraulicproject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addCustomerLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerLocationId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerLocations",
                columns: table => new
                {
                    CustomerLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLocations", x => x.CustomerLocationId);
                });

            migrationBuilder.InsertData(
                table: "CustomerLocations",
                columns: new[] { "CustomerLocationId", "Address", "City", "Country", "LocationName", "Notes", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "", "", "", "ATL", "", "", "" },
                    { 2, "", "", "", "DFW", "", "", "" },
                    { 3, "", "", "", "HOU", "", "", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomerLocationId",
                table: "AspNetUsers",
                column: "CustomerLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CustomerLocations_CustomerLocationId",
                table: "AspNetUsers",
                column: "CustomerLocationId",
                principalTable: "CustomerLocations",
                principalColumn: "CustomerLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CustomerLocations_CustomerLocationId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CustomerLocations");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CustomerLocationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CustomerLocationId",
                table: "AspNetUsers");
        }
    }
}
