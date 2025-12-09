using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_DangXuanDuc_21103101079.Migrations
{
    public partial class bang1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PublicationYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Author", "Price", "PublicationYear", "Title" },
                values: new object[] { 1, "F. Scott Fitzgerald", 10.99m, 1925, "The Great Gatsby" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Author", "Price", "PublicationYear", "Title" },
                values: new object[] { 2, "Harper Lee", 7.99m, 1960, "To Kill a Mockingbird" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Author", "Price", "PublicationYear", "Title" },
                values: new object[] { 3, "George Orwell", 8.99m, 1949, "1984" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
