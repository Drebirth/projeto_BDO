using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoBDO.Migrations
{
    /// <inheritdoc />
    public partial class atualizacaoPersonagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "usuario",
                table: "Personagens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usuario",
                table: "Personagens");
        }
    }
}
