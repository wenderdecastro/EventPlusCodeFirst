using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApi.EventPlus.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "exibir",
                table: "ComentariosEvento",
                type: "BIT",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "exibir",
                table: "ComentariosEvento",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BIT");
        }
    }
}
