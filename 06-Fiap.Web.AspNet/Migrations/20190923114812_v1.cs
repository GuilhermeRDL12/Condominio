using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _06_Fiap.Web.AspNet.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Construtoras",
                columns: table => new
                {
                    ConstrutoraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Construtoras", x => x.ConstrutoraId);
                });

            migrationBuilder.CreateTable(
                name: "Sindicos",
                columns: table => new
                {
                    SindicoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sindicos", x => x.SindicoId);
                });

            migrationBuilder.CreateTable(
                name: "TblCondominio",
                columns: table => new
                {
                    CondominioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 40, nullable: false),
                    Blocos = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    SindicoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCondominio", x => x.CondominioId);
                    table.ForeignKey(
                        name: "FK_TblCondominio_Sindicos_SindicoId",
                        column: x => x.SindicoId,
                        principalTable: "Sindicos",
                        principalColumn: "SindicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CondominioConstrutora",
                columns: table => new
                {
                    ConstrutoraId = table.Column<int>(nullable: false),
                    CondominioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondominioConstrutora", x => new { x.ConstrutoraId, x.CondominioId });
                    table.ForeignKey(
                        name: "FK_CondominioConstrutora_TblCondominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "TblCondominio",
                        principalColumn: "CondominioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CondominioConstrutora_Construtoras_ConstrutoraId",
                        column: x => x.ConstrutoraId,
                        principalTable: "Construtoras",
                        principalColumn: "ConstrutoraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imoveis",
                columns: table => new
                {
                    ImovelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<string>(nullable: true),
                    AreaUtil = table.Column<float>(nullable: false),
                    CondominioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imoveis", x => x.ImovelId);
                    table.ForeignKey(
                        name: "FK_Imoveis_TblCondominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "TblCondominio",
                        principalColumn: "CondominioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CondominioConstrutora_CondominioId",
                table: "CondominioConstrutora",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_CondominioId",
                table: "Imoveis",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCondominio_SindicoId",
                table: "TblCondominio",
                column: "SindicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CondominioConstrutora");

            migrationBuilder.DropTable(
                name: "Imoveis");

            migrationBuilder.DropTable(
                name: "Construtoras");

            migrationBuilder.DropTable(
                name: "TblCondominio");

            migrationBuilder.DropTable(
                name: "Sindicos");
        }
    }
}
