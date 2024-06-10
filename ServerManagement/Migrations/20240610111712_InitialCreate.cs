using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServerManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    ServerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.ServerId);
                });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "ServerId", "City", "IsOnline", "Name", "NumberOfPeople" },
                values: new object[,]
                {
                    { 1, "Toronto", false, "Server1", 0 },
                    { 2, "Toronto", true, "Server2", 7 },
                    { 3, "Toronto", false, "Server3", 78 },
                    { 4, "Toronto", true, "Server4", 19 },
                    { 5, "Montreal", false, "Server5", 66 },
                    { 6, "Montreal", false, "Server6", 16 },
                    { 7, "Montreal", false, "Server7", 70 },
                    { 8, "Ottawa", true, "Server8", 10 },
                    { 9, "Ottawa", true, "Server9", 17 },
                    { 10, "Calgary", false, "Server10", 84 },
                    { 11, "Calgary", true, "Server11", 87 },
                    { 12, "Halifax", false, "Server12", 4 },
                    { 13, "Halifax", true, "Server13", 95 },
                    { 14, "Halifax", true, "Server14", 68 },
                    { 15, "Halifax", true, "Server15", 66 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
