using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Transmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ImageUrl", "Make", "Transmission", "Year" },
                values: new object[,]
                {
                    { 1, "https://img.classistatic.de/api/v1/mo-prod/images/42/42356da7-a4e3-4b3c-ba91-e029f7334251?rule=mo-1600.jpg", "Toyota Corolla", "Manual", 2021 },
                    { 2, "https://img.classistatic.de/api/v1/mo-prod/images/46/46681d0d-16d3-44a9-b14b-8de4607ae5de?rule=mo-1600.jpg", "Ford Fiesta", "Manual", 2019 },
                    { 3, "https://img.classistatic.de/api/v1/mo-prod/images/2a/2a0663b7-98f3-48f8-9d9d-5200aefbf0b4?rule=mo-1600.jpg", "BMW 3 Series", "Automatic", 2020 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
