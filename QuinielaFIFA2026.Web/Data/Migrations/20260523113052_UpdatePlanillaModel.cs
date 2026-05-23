using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuinielaFIFA2026.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlanillaModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planillas_Users_UserId",
                table: "Planillas");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Planillas",
                newName: "Codigo");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Planillas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "AssignedAt",
                table: "Planillas",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Planillas_Users_UserId",
                table: "Planillas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planillas_Users_UserId",
                table: "Planillas");

            migrationBuilder.DropColumn(
                name: "AssignedAt",
                table: "Planillas");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Planillas",
                newName: "Nombre");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Planillas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Planillas_Users_UserId",
                table: "Planillas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
