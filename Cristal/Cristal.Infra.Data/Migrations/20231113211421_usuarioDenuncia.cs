using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cristal.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class usuarioDenuncia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GuidUsuario",
                table: "DENUNCIA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DENUNCIA_GuidUsuario",
                table: "DENUNCIA",
                column: "GuidUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_DENUNCIA_USUARIO_GuidUsuario",
                table: "DENUNCIA",
                column: "GuidUsuario",
                principalTable: "USUARIO",
                principalColumn: "GUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DENUNCIA_USUARIO_GuidUsuario",
                table: "DENUNCIA");

            migrationBuilder.DropIndex(
                name: "IX_DENUNCIA_GuidUsuario",
                table: "DENUNCIA");

            migrationBuilder.DropColumn(
                name: "GuidUsuario",
                table: "DENUNCIA");
        }
    }
}
