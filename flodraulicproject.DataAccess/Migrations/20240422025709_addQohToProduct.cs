using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace flodraulicproject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addQohToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Qoh",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartQoh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "PartNumber", "StartQoh" },
                values: new object[,]
                {
                    { 1, "2000-3900", 1 },
                    { 2, "219-2370", 10 },
                    { 3, "031-6450", 0 },
                    { 4, "222-6780", 4 }
                });

            migrationBuilder.UpdateData(
                table: "PartFamilies",
                keyColumn: "Id",
                keyValue: 1,
                column: "FamilyName",
                value: "Tractor");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Qoh",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Qoh",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Qoh",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Qoh",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropColumn(
                name: "Qoh",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "PartFamilies",
                keyColumn: "Id",
                keyValue: 1,
                column: "FamilyName",
                value: "Truck");
        }
    }
}
