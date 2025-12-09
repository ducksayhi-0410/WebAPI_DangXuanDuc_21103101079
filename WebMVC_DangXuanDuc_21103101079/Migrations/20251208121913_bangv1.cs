using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMVC_DangXuanDuc_21103101079.Migrations
{
    public partial class bangv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Director = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Director", "Rating", "ReleaseYear", "Title" },
                values: new object[] { 1, "Christopher Nolan", 9, 2010, "Inception" });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Director", "Rating", "ReleaseYear", "Title" },
                values: new object[] { 2, "Steven Spielberg", 8, 1993, "Jurassic Park" });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Director", "Rating", "ReleaseYear", "Title" },
                values: new object[] { 3, "Quentin Tarantino", 9, 1994, "Pulp Fiction" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
