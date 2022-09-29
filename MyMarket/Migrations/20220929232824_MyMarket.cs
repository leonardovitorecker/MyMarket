using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyMarket.Migrations
{
    public partial class MyMarket : Migration
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
                name: "estoques",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    estoqueAtual = table.Column<int>(type: "integer", nullable: false),
                    produtoid = table.Column<int>(type: "integer", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estoques", x => x.id);
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
                    idUsuario = table.Column<int>(type: "integer", nullable: false),
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
                name: "pedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idUsuario = table.Column<int>(type: "integer", nullable: false),
                    usuarioid = table.Column<int>(type: "integer", nullable: false),
                    valorTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_pedidos_usuarios_usuarioid",
                        column: x => x.usuarioid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "itempedidosprodutos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantidadeItemProduto = table.Column<int>(type: "integer", nullable: false),
                    precoItemProduto = table.Column<decimal>(type: "numeric", nullable: false),
                    idproduto = table.Column<int>(type: "integer", nullable: false),
                    idpedido = table.Column<int>(type: "integer", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Pedidoid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itempedidosprodutos", x => x.id);
                    table.ForeignKey(
                        name: "FK_itempedidosprodutos_pedidos_Pedidoid",
                        column: x => x.Pedidoid,
                        principalTable: "pedidos",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_enderecos_usuarioid",
                table: "enderecos",
                column: "usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_itempedidosprodutos_Pedidoid",
                table: "itempedidosprodutos",
                column: "Pedidoid");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_usuarioid",
                table: "pedidos",
                column: "usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_categoriaid",
                table: "produtos",
                column: "categoriaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enderecos");

            migrationBuilder.DropTable(
                name: "estoques");

            migrationBuilder.DropTable(
                name: "itempedidosprodutos");

            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "pedidos");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
