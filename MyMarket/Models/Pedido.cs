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
       public List<Carrinho> carrinho { get; set; }
        public int recordId { get; set; }
        public decimal valorTotal { get; set; }
        public DateTime dataCadastro { get; set; } = DateTime.Now;
    }
}
