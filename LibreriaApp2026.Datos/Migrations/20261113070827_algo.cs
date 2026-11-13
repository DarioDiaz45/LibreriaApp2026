using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaApp2026.Datos.Migrations
{
    /// <inheritdoc />
    public partial class algo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "FormasDePago",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "FormasDePago");
        }
    }
}
