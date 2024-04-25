using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cristal.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class usuarioDenuncia2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DENUNCIA_USUARIO_GuidUsuario",
                table: "DENUNCIA");

            migrationBuilder.RenameColumn(
                name: "GuidUsuario",
                table: "DENUNCIA",
                newName: "GUIDUSUARIO");

            migrationBuilder.RenameIndex(
                name: "IX_DENUNCIA_GuidUsuario",
                table: "DENUNCIA",
                newName: "IX_DENUNCIA_GUIDUSUARIO");

            migrationBuilder.AlterColumn<Guid>(
                name: "GUIDUSUARIO",
                table: "DENUNCIA",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DENUNCIA_USUARIO_GUIDUSUARIO",
                table: "DENUNCIA",
                column: "GUIDUSUARIO",
                principalTable: "USUARIO",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DENUNCIA_USUARIO_GUIDUSUARIO",
                table: "DENUNCIA");

            migrationBuilder.RenameColumn(
                name: "GUIDUSUARIO",
                table: "DENUNCIA",
                newName: "GuidUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_DENUNCIA_GUIDUSUARIO",
                table: "DENUNCIA",
                newName: "IX_DENUNCIA_GuidUsuario");

            migrationBuilder.AlterColumn<Guid>(
                name: "GuidUsuario",
                table: "DENUNCIA",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_DENUNCIA_USUARIO_GuidUsuario",
                table: "DENUNCIA",
                column: "GuidUsuario",
                principalTable: "USUARIO",
                principalColumn: "GUID");
        }
    }
}
