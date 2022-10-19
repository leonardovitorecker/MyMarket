using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMarket.Models
{
    public class PedidoDetalhe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PedidoDetalheId { get; set; }
        public int PedidoId { get; set; }
        public int produtoId { get; set; }
        public int quantidade { get; set; }
        public decimal UnitPreco { get; set; }
        public virtual Produto produto { get; set; }
        public virtual Pedido pedido { get; set; }
    }
}
