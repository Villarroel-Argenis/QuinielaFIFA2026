using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QuinielaFIFA2026.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPrediccionClasificacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrediccionesClasificacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlanillaId = table.Column<int>(type: "integer", nullable: false),
                    Slot = table.Column<string>(type: "text", nullable: false),
                    EquipoElegido = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrediccionesClasificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrediccionesClasificacion_Planillas_PlanillaId",
                        column: x => x.PlanillaId,
                        principalTable: "Planillas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrediccionesClasificacion_PlanillaId",
                table: "PrediccionesClasificacion",
                column: "PlanillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrediccionesClasificacion");
        }
    }
}
