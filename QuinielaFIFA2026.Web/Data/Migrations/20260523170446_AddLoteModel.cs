using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QuinielaFIFA2026.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLoteModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoteId",
                table: "Planillas",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planillas_LoteId",
                table: "Planillas",
                column: "LoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planillas_Lotes_LoteId",
                table: "Planillas",
                column: "LoteId",
                principalTable: "Lotes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planillas_Lotes_LoteId",
                table: "Planillas");

            migrationBuilder.DropTable(
                name: "Lotes");

            migrationBuilder.DropIndex(
                name: "IX_Planillas_LoteId",
                table: "Planillas");

            migrationBuilder.DropColumn(
                name: "LoteId",
                table: "Planillas");
        }
    }
}
