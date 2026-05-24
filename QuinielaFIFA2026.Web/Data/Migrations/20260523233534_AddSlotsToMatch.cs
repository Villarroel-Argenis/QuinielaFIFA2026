using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuinielaFIFA2026.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSlotsToMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AwaySlot",
                table: "Matches",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeSlot",
                table: "Matches",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwaySlot",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeSlot",
                table: "Matches");
        }
    }
}
