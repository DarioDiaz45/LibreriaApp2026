using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaApp2026.Datos.Migrations
{
    /// <inheritdoc />
    public partial class RowVersionHecho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Temas",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Libros",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Editoriales",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Autores",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Temas");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Editoriales");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Autores");
        }
    }
}
