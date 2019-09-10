using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace judocas.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdRG",
                table: "Filiado");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "RG",
                newName: "NUMERO");

            migrationBuilder.RenameColumn(
                name: "OrgaoExpedidor",
                table: "RG",
                newName: "ORGAO_EXPEDIDOR");

            migrationBuilder.AlterColumn<string>(
                name: "NUMERO",
                table: "RG",
                type: "nvarchar(7)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ORGAO_EXPEDIDOR",
                table: "RG",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    IdEndereco = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_FILIADO = table.Column<long>(type: "BIGINT", nullable: false),
                    RUA = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    NUMERO = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    BAIRRO = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    CIDADE = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    ESTADO = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.IdEndereco);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    ID_PROFESSOR = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    REGISTRO_CBJ = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    TELEFONE_1 = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    TELEFONE_2 = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    OBSERVACOES = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    RGIdRG = table.Column<long>(nullable: true),
                    DATA_NASC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FaixaIdFaixa = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.ID_PROFESSOR);
                    table.ForeignKey(
                        name: "FK_Professor_Faixa_FaixaIdFaixa",
                        column: x => x.FaixaIdFaixa,
                        principalTable: "Faixa",
                        principalColumn: "ID_FAIXA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Professor_RG_RGIdRG",
                        column: x => x.RGIdRG,
                        principalTable: "RG",
                        principalColumn: "ID_RG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    ID_ALUNO = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    REGISTRO_CBJ = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    TELEFONE_1 = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    TELEFONE_2 = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    OBSERVACOES = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    RGIdRG = table.Column<long>(nullable: true),
                    DATA_NASC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FaixaIdFaixa = table.Column<long>(nullable: true),
                    EnderecoIdEndereco = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.ID_ALUNO);
                    table.ForeignKey(
                        name: "FK_Aluno_ENDERECO_EnderecoIdEndereco",
                        column: x => x.EnderecoIdEndereco,
                        principalTable: "ENDERECO",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aluno_Faixa_FaixaIdFaixa",
                        column: x => x.FaixaIdFaixa,
                        principalTable: "Faixa",
                        principalColumn: "ID_FAIXA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aluno_RG_RGIdRG",
                        column: x => x.RGIdRG,
                        principalTable: "RG",
                        principalColumn: "ID_RG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_EnderecoIdEndereco",
                table: "Aluno",
                column: "EnderecoIdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_FaixaIdFaixa",
                table: "Aluno",
                column: "FaixaIdFaixa");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_RGIdRG",
                table: "Aluno",
                column: "RGIdRG");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_FaixaIdFaixa",
                table: "Professor",
                column: "FaixaIdFaixa");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_RGIdRG",
                table: "Professor",
                column: "RGIdRG");

            migrationBuilder.AddForeignKey(
                name: "FK_Filiado_ENDERECO_ID_FILIADO",
                table: "Filiado",
                column: "ID_FILIADO",
                principalTable: "ENDERECO",
                principalColumn: "IdEndereco",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filiado_ENDERECO_ID_FILIADO",
                table: "Filiado");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "ENDERECO");

            migrationBuilder.RenameColumn(
                name: "NUMERO",
                table: "RG",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "ORGAO_EXPEDIDOR",
                table: "RG",
                newName: "OrgaoExpedidor");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "RG",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)");

            migrationBuilder.AlterColumn<string>(
                name: "OrgaoExpedidor",
                table: "RG",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AddColumn<long>(
                name: "IdRG",
                table: "Filiado",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
