using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cristal.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class denuncia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LATITUDE = table.Column<double>(type: "float", nullable: false),
                    LONGITUDE = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "DENUNCIA",
                columns: table => new
                {
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TITULO = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    GUIDENDERECO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FOTO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    DATAHORACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QUANTIDADEMAMIFERO = table.Column<int>(type: "int", nullable: false),
                    QUANTIDADEAVES = table.Column<int>(type: "int", nullable: false),
                    QUANTIDADEREPTEIS = table.Column<int>(type: "int", nullable: false),
                    QUANTIDADEANFIBIOS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DENUNCIA", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_DENUNCIA_ENDERECO_GUIDENDERECO",
                        column: x => x.GUIDENDERECO,
                        principalTable: "ENDERECO",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DENUNCIA_GUIDENDERECO",
                table: "DENUNCIA",
                column: "GUIDENDERECO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DENUNCIA");

            migrationBuilder.DropTable(
                name: "ENDERECO");
        }
    }
}
