using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStack.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", nullable: true),
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoGames_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, "Rockstar Games is a video game publisher that is a wholly owned subsidiary of Take-Two Interactive. The publisher is known for the Grand Theft Auto, Max Payne, and Red Dead series.", "Rockstar Games" },
                    { 2, "Mojang Studios is a Swedish video game developer and a studio of Xbox Game Studios based in Stockholm. It was founded by Markus Persson in 2009 as Mojang Specifications, inheriting the name from a previous video game venture he left two years prior.", "Mojang" },
                    { 3, "CD Projekt S.A. is a Polish video game developer, publisher and distributor based in Warsaw, founded in May 1994 by Marcin Iwiński and Michał Kiciński. They are mostly known for their The Witcher series.", "CD Projekt" },
                    { 4, "Quantic Dream S.A. is a French video game developer and publisher based in Paris. Founded in May 1997, Quantic Dream is known for its interactive drama story driven games such as Heavy Rain, Beyond: Two Souls, and Detroit: Become Human.", "Quantic Dream" },
                    { 5, "Santa Monica Studio is an American video game developer and part of SIE Worldwide Studios, which is owned by Sony Interactive Entertainment. They are known for their God of War series.", "Santa Monica Studio" }
                });

            migrationBuilder.InsertData(
                table: "VideoGames",
                columns: new[] { "Id", "PublisherId", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, 1, 2013, "Grand Theft Auto 5" },
                    { 2, 1, 2018, "Red Dead Redemption 2" },
                    { 3, 1, 2025, "Grand Theft Auto 6" },
                    { 4, 2, 2011, "Minecraft" },
                    { 5, 3, 2020, "Cyberpunk 2077" },
                    { 6, 4, 2018, "Detroit: Become Human" },
                    { 7, 5, 2022, "God of War Ragnarök" },
                    { 8, 3, 2015, "The Witcher 3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_PublisherId",
                table: "VideoGames",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoGames");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
