using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoBDO.Migrations
{
    /// <inheritdoc />
    public partial class mudancaEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Spot",
                table: "Itens");

            migrationBuilder.AddColumn<long>(
                name: "SpotId",
                table: "Itens",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Itens_SpotId",
                table: "Itens",
                column: "SpotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Spots_SpotId",
                table: "Itens",
                column: "SpotId",
                principalTable: "Spots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Spots_SpotId",
                table: "Itens");

            migrationBuilder.DropIndex(
                name: "IX_Itens_SpotId",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "SpotId",
                table: "Itens");

            migrationBuilder.AddColumn<string>(
                name: "Spot",
                table: "Itens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
