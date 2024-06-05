using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VotingSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VotedOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VotedOnParty = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Votes",
                columns: new[] { "Id", "VotedOn", "VotedOnParty", "Voter" },
                values: new object[,]
                {
                    { 1, "Bob", "Green", "Philip" },
                    { 2, "Charlie", "Red", "Peter" },
                    { 3, "Alice", "Blue", "Sune" },
                    { 4, "Thomas", "Yellow", "Max" },
                    { 5, "Dutch", "Purple", "Lucas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");
        }
    }
}
