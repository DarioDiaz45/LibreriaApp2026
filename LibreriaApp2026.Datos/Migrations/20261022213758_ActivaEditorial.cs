using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaApp2026.Datos.Migrations
{
    /// <inheritdoc />
    public partial class ActivaEditorial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Editoriales",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Editoriales");
        }
    }
}
