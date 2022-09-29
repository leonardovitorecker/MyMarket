using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMarket.Models
{
    public class ItemPedidoProduto
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int quantidadeItemProduto { get; set; }
        public decimal precoItemProduto { get; set; }
        public int idproduto { get; set; }
        public int idpedido { get; set; }
        public DateTime dataCadastro { get; set; } = DateTime.Now;
        public DateTime dataAlteracao { get; set; } = DateTime.Now;
    }
}
