﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyMarket.Database;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyMarket.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20221107225951_databae")]
    partial class databae
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyMarket.Models.Carrinho", b =>
                {
                    b.Property<int>("recordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("recordId"));

                    b.Property<string>("CarrinhoId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("count")
                        .HasColumnType("integer");

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("produtoId")
                        .HasColumnType("integer");

                    b.HasKey("recordId");

                    b.HasIndex("produtoId");

                    b.ToTable("carrinhos");
                });

            modelBuilder.Entity("MyMarket.Models.Categoria", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("categorias");
                });

            modelBuilder.Entity("MyMarket.Models.Endereco", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("bairro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("cep")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("cidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("complemento")
                        .HasColumnType("text");

                    b.Property<DateTime>("dataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("numeroCasa")
                        .HasColumnType("integer");

                    b.Property<string>("rua")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("usuarioid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("usuarioid");

                    b.ToTable("enderecos");
                });

            modelBuilder.Entity("MyMarket.Models.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("dataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("produtoid")
                        .HasColumnType("integer");

                    b.Property<int>("usuarioid")
                        .HasColumnType("integer");

                    b.Property<decimal>("valorTotal")
                        .HasColumnType("numeric");

                    b.HasKey("id");

                    b.ToTable("pedidos");
                });

            modelBuilder.Entity("MyMarket.Models.PedidoDetalhe", b =>
                {
                    b.Property<int>("PedidoDetalheId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PedidoDetalheId"));

                    b.Property<int>("PedidoId")
                        .HasColumnType("integer");

                    b.Property<decimal>("UnitPreco")
                        .HasColumnType("numeric");

                    b.Property<int>("produtoId")
                        .HasColumnType("integer");

                    b.Property<int>("quantidade")
                        .HasColumnType("integer");

                    b.HasKey("PedidoDetalheId");

                    b.HasIndex("PedidoId");

                    b.HasIndex("produtoId");

                    b.ToTable("PedidoDetalhes");
                });

            modelBuilder.Entity("MyMarket.Models.Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<byte[]>("arquivo")
                        .HasColumnType("bytea");

                    b.Property<int>("categoriaid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("dataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("dataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("estoque")
                        .HasColumnType("integer");

                    b.Property<string>("imagem")
                        .HasColumnType("text");

                    b.Property<string>("nomeProduto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("valorVenda")
                        .HasColumnType("numeric");

                    b.HasKey("id");

                    b.HasIndex("categoriaid");

                    b.ToTable("produtos");
                });

            modelBuilder.Entity("MyMarket.Models.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("confirmarSenha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("cpf")
                        .HasColumnType("text");

                    b.Property<DateTime>("dataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("dataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("MyMarket.Models.Carrinho", b =>
                {
                    b.HasOne("MyMarket.Models.Produto", "produto")
                        .WithMany()
                        .HasForeignKey("produtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("produto");
                });

            modelBuilder.Entity("MyMarket.Models.Endereco", b =>
                {
                    b.HasOne("MyMarket.Models.Usuario", null)
                        .WithMany("enderecos")
                        .HasForeignKey("usuarioid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyMarket.Models.PedidoDetalhe", b =>
                {
                    b.HasOne("MyMarket.Models.Pedido", "pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyMarket.Models.Produto", "produto")
                        .WithMany()
                        .HasForeignKey("produtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pedido");

                    b.Navigation("produto");
                });

            modelBuilder.Entity("MyMarket.Models.Produto", b =>
                {
                    b.HasOne("MyMarket.Models.Categoria", null)
                        .WithMany("produtos")
                        .HasForeignKey("categoriaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyMarket.Models.Categoria", b =>
                {
                    b.Navigation("produtos");
                });

            modelBuilder.Entity("MyMarket.Models.Usuario", b =>
                {
                    b.Navigation("enderecos");
                });
#pragma warning restore 612, 618
        }
    }
}
