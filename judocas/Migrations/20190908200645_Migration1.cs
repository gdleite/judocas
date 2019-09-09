using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace judocas.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RG",
                columns: table => new
                {
                    ID_RG = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_FILIADO = table.Column<long>(type: "BIGINT", nullable: false),
                    Numero = table.Column<string>(nullable: true),
                    OrgaoExpedidor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RG", x => x.ID_RG);
                });

            migrationBuilder.CreateTable(
                name: "Filiado",
                columns: table => new
                {
                    ID_FILIADO = table.Column<long>(type: "BIGINT", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    REGISTRO_CBJ = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    TELEFONE_1 = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    TELEFONE_2 = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    OBSERVACOES = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IdRG = table.Column<long>(nullable: false),
                    DATA_NASC = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiado", x => x.ID_FILIADO);
                    table.ForeignKey(
                        name: "FK_Filiado_RG_ID_FILIADO",
                        column: x => x.ID_FILIADO,
                        principalTable: "RG",
                        principalColumn: "ID_RG",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faixa",
                columns: table => new
                {
                    ID_FAIXA = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_FILIADO = table.Column<long>(type: "BIGINT", nullable: false),
                    DATA_ENTREGA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DESCRICAO_FAIXA = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faixa", x => x.ID_FAIXA);
                    table.ForeignKey(
                        name: "FK_Faixa_Filiado_ID_FILIADO",
                        column: x => x.ID_FILIADO,
                        principalTable: "Filiado",
                        principalColumn: "ID_FILIADO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faixa_ID_FILIADO",
                table: "Faixa",
                column: "ID_FILIADO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faixa");

            migrationBuilder.DropTable(
                name: "Filiado");

            migrationBuilder.DropTable(
                name: "RG");
        }
    }
}
