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
    [Migration("20220930000634_Mymarket")]
    partial class Mymarket
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

            modelBuilder.Entity("MyMarket.Models.Estoque", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("dataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("dataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("estoqueAtual")
                        .HasColumnType("integer");

                    b.Property<int>("produtoid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("estoques");
                });

            modelBuilder.Entity("MyMarket.Models.ItemPedidoProduto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int?>("Pedidoid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("dataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("dataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("idpedido")
                        .HasColumnType("integer");

                    b.Property<int>("idproduto")
                        .HasColumnType("integer");

                    b.Property<decimal>("precoItemProduto")
                        .HasColumnType("numeric");

                    b.Property<int>("quantidadeItemProduto")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("Pedidoid");

                    b.ToTable("itempedidosprodutos");
                });

            modelBuilder.Entity("MyMarket.Models.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("dataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("idUsuario")
                        .HasColumnType("integer");

                    b.Property<int>("usuarioid")
                        .HasColumnType("integer");

                    b.Property<decimal>("valorTotal")
                        .HasColumnType("numeric");

                    b.HasKey("id");

                    b.HasIndex("usuarioid");

                    b.ToTable("pedidos");
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

            modelBuilder.Entity("MyMarket.Models.Endereco", b =>
                {
                    b.HasOne("MyMarket.Models.Usuario", null)
                        .WithMany("enderecos")
                        .HasForeignKey("usuarioid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyMarket.Models.ItemPedidoProduto", b =>
                {
                    b.HasOne("MyMarket.Models.Pedido", null)
                        .WithMany("produtos")
                        .HasForeignKey("Pedidoid");
                });

            modelBuilder.Entity("MyMarket.Models.Pedido", b =>
                {
                    b.HasOne("MyMarket.Models.Usuario", "usuario")
                        .WithMany("pedidos")
                        .HasForeignKey("usuarioid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usuario");
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

            modelBuilder.Entity("MyMarket.Models.Pedido", b =>
                {
                    b.Navigation("produtos");
                });

            modelBuilder.Entity("MyMarket.Models.Usuario", b =>
                {
                    b.Navigation("enderecos");

                    b.Navigation("pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
