using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoBDO.Migrations
{
    /// <inheritdoc />
    public partial class atualizacaoEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpotNome",
                table: "Itens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpotNome",
                table: "Itens");
        }
    }
}
