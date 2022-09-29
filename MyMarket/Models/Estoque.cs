using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMarket.Models
{
    public class Estoque
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int estoqueAtual { get; set; }
        public int produtoid { get; set; }
        public DateTime dataCadastro { get; set; } = DateTime.Now;
        public DateTime dataAlteracao { get; set; } = DateTime.Now;
    }
}
