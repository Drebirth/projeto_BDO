using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoBDO.Migrations
{
    /// <inheritdoc />
    public partial class DBv20004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name:"FK_Itens_Grinds_GrindId",
                table: "Itens"
            );

            migrationBuilder.DropIndex(
                name:"IX_Itens_GrindId",
                table:"Grind"
            );

            migrationBuilder.DropColumn(
                name:"GrindId",
                table:"Grind"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
