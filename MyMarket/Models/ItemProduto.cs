using System.ComponentModel.DataAnnotations;

namespace MyMarket.Models
{
    public class ItemProduto
    {
        [Key]
        public int Id { get; set; }
        public int produtoId { get; set; }
        public int pedidoId { get; set; }
        public int quantidade { get; set; }
        public virtual Produto Produto { get; set; }  
        public virtual Pedido Pedido { get; set; }
    }
}
