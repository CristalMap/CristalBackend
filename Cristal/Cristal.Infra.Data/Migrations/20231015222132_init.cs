using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cristal.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TELEFONE = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DATAHORACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PONTO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.GUID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_EMAIL",
                table: "USUARIO",
                column: "EMAIL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
