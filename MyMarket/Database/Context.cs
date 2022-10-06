using Microsoft.EntityFrameworkCore;
using MyMarket.Models;

namespace MyMarket.Database
{
    public class Context: DbContext
    {
            public Context(DbContextOptions<Context> opcoes)
             : base(opcoes) { }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
            }

            public DbSet<Usuario> usuarios { get; set; }
            public DbSet<Endereco> enderecos { get; set; }
            public DbSet<Produto> produtos { get; set; }
            public DbSet<Categoria> categorias { get; set; }
            public DbSet<ItemPedidoProduto> itempedidosprodutos { get; set; }
            public DbSet<Pedido> pedidos { get; set; }
             


    }
}
