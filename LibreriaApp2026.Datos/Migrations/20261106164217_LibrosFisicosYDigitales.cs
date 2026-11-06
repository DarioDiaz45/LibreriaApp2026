using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaApp2026.Datos.Migrations
{
    /// <inheritdoc />
    public partial class LibrosFisicosYDigitales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Libros_ISBN",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Libros");

            migrationBuilder.DropColumn(
             name: "RowVersion",
             table: "Temas");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Temas",
                type: "rowversion",
                rowVersion: true,
                nullable: false);

            migrationBuilder.DropColumn(
              name: "RowVersion",
              table: "Libros");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Libros",
                type: "rowversion",
                rowVersion: true,
                nullable: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Libros",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.DropColumn(
                 name: "RowVersion",
                 table: "Autores");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Autores",
                type: "rowversion",
                rowVersion: true,
                nullable: false);

            migrationBuilder.CreateTable(
                name: "LibrosDigitales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Identificador = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Formato = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TamanoArchivo = table.Column<long>(type: "bigint", nullable: false),
                    UrlDescarga = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibrosDigitales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibrosDigitales_Libros_Id",
                        column: x => x.Id,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LibrosFisicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibrosFisicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibrosFisicos_Libros_Id",
                        column: x => x.Id,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibrosDigitales_Identificador",
                table: "LibrosDigitales",
                column: "Identificador",
                unique: true,
                filter: "[Identificador] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LibrosFisicos_ISBN",
                table: "LibrosFisicos",
                column: "ISBN",
                unique: true,
                filter: "[ISBN] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibrosDigitales");

            migrationBuilder.DropTable(
                name: "LibrosFisicos");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Libros");

            migrationBuilder.AlterColumn<byte[]>(
                name: "RowVersion",
                table: "Temas",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "rowversion",
                oldRowVersion: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "RowVersion",
                table: "Libros",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "rowversion",
                oldRowVersion: true);

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Libros",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Libros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "RowVersion",
                table: "Autores",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "rowversion",
                oldRowVersion: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libros_ISBN",
                table: "Libros",
                column: "ISBN",
                unique: true);
        }
    }
}
