using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyMarket.Migrations
{
    public partial class MYMARKET : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usuarioid = table.Column<int>(type: "integer", nullable: false),
                    produtoid = table.Column<int>(type: "integer", nullable: false),
                    valorTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false),
                    confirmarSenha = table.Column<string>(type: "text", nullable: false),
                    cpf = table.Column<string>(type: "text", nullable: true),
                    telefone = table.Column<string>(type: "text", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomeProduto = table.Column<string>(type: "text", nullable: false),
                    arquivo = table.Column<byte[]>(type: "bytea", nullable: true),
                    estoque = table.Column<int>(type: "integer", nullable: false),
                    imagem = table.Column<string>(type: "text", nullable: true),
                    valorVenda = table.Column<decimal>(type: "numeric", nullable: false),
                    categoriaid = table.Column<int>(type: "integer", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_produtos_categorias_categoriaid",
                        column: x => x.categoriaid,
                        principalTable: "categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enderecos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cidade = table.Column<string>(type: "text", nullable: false),
                    cep = table.Column<string>(type: "text", nullable: false),
                    bairro = table.Column<string>(type: "text", nullable: false),
                    rua = table.Column<string>(type: "text", nullable: false),
                    numeroCasa = table.Column<int>(type: "integer", nullable: false),
                    complemento = table.Column<string>(type: "text", nullable: true),
                    usuarioid = table.Column<int>(type: "integer", nullable: false),
                    dataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enderecos", x => x.id);
                    table.ForeignKey(
                        name: "FK_enderecos_usuarios_usuarioid",
                        column: x => x.usuarioid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "carrinhos",
                columns: table => new
                {
                    recordId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarrinhoId = table.Column<string>(type: "text", nullable: false),
                    produtoId = table.Column<int>(type: "integer", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    dateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carrinhos", x => x.recordId);
                    table.ForeignKey(
                        name: "FK_carrinhos_produtos_produtoId",
                        column: x => x.produtoId,
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoDetalhes",
                columns: table => new
                {
                    PedidoDetalheId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PedidoId = table.Column<int>(type: "integer", nullable: false),
                    produtoId = table.Column<int>(type: "integer", nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    UnitPreco = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoDetalhes", x => x.PedidoDetalheId);
                    table.ForeignKey(
                        name: "FK_PedidoDetalhes_pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "pedidos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoDetalhes_produtos_produtoId",
                        column: x => x.produtoId,
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carrinhos_produtoId",
                table: "carrinhos",
                column: "produtoId");

            migrationBuilder.CreateIndex(
                name: "IX_enderecos_usuarioid",
                table: "enderecos",
                column: "usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalhes_PedidoId",
                table: "PedidoDetalhes",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalhes_produtoId",
                table: "PedidoDetalhes",
                column: "produtoId");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_categoriaid",
                table: "produtos",
                column: "categoriaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carrinhos");

            migrationBuilder.DropTable(
                name: "enderecos");

            migrationBuilder.DropTable(
                name: "PedidoDetalhes");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "pedidos");

            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "categorias");
        }
    }
}
