using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMarket.Models
{
    public class Pedido
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int idUsuario { get; set; }
        public Usuario usuario { get; set; }
        public ICollection<ItemPedidoProduto> produtos { get; set; }
        public decimal valorTotal { get; set; }
        public DateTime dataCadastro { get; set; } = DateTime.Now;
    }
}
