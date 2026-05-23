using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuinielaFIFA2026.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsActiveFromPlanilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Planillas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Planillas",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
