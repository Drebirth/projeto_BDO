using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoBDO.Migrations
{
    /// <inheritdoc />
    public partial class DBv20002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GrindId",
                table: "Itens",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Itens_GrindId",
                table: "Itens",
                column: "GrindId");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Grinds_GrindId",
                table: "Itens",
                column: "GrindId",
                principalTable: "Grinds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Grinds_GrindId",
                table: "Itens");

            migrationBuilder.DropIndex(
                name: "IX_Itens_GrindId",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "GrindId",
                table: "Itens");
        }
    }
}
