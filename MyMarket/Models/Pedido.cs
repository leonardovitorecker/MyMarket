using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMarket.Models
{
    public class Pedido
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int usuarioid { get; set; }
        public decimal valorTotal { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<ItemProduto> itensProdutos { get; set; }
        public DateTime dataPedido { get; set; } = DateTime.Now;
    }
}
