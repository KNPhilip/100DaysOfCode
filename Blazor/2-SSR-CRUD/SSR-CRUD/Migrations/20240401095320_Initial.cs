using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SSRCRUD.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideoGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGames", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "VideoGames",
                columns: new[] { "Id", "Publisher", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "Rockstar Games", 2013, "Grand Theft Auto 5" },
                    { 2, "Rockstar Games", 2018, "Red Dead Redemption 2" },
                    { 3, "Rockstar Games", 2025, "Grand Theft Auto 6" },
                    { 4, "Mojang", 2011, "Minecraft" },
                    { 5, "CD Project", 2020, "Cyberpunk 2077" },
                    { 6, "Quantic Dream", 2018, "Detroit: Become Human" },
                    { 7, "Santa Monica Studio", 2022, "God of War Ragnarök" },
                    { 8, "CD Project", 2015, "The Witcher 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoGames");
        }
    }
}
