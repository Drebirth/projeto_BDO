using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoBDO.Migrations
{
    /// <inheritdoc />
    public partial class DBv20003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Quantidades",
                table: "Grinds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidades",
                table: "Grinds");
        }
    }
}
