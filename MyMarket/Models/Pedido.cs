using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMarket.Models
{
    public class Pedido
    {
        public enum SituacaoPedido
        {
            Carrinho,
            Realizado,
            Verificado,
            Atendido,
            Entregue,
            Cancelado
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int pedidoId { get; set; }
        public int idUsuario { get; set; }
        public SituacaoPedido Situacao { get; set; }
        public int? enderecoId { get; set; }
        public decimal valorTotal { get; set; }
        public DateTime dataPagamento { get; set; } = DateTime.Now;
        public virtual Usuario usuario { get; set; }
       public System.DateTime dataPagamentoDate { get; set;} = DateTime.Now;    

        public List<PedidoDetalhe> pedidoDetalhes { get; set; }
    }
}
