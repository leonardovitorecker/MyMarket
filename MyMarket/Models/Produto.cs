using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMarket.Models
{
    public class Produto
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nomeProduto { get; set; }
   
        public int estoque { get; set; }
       
        public decimal valorVenda { get; set; }
 
        public int? estoqueAnterior { get; set; }
        public int categoriaid { get; set; }
        public DateTime dataCadastro { get; set; } = DateTime.Now;
        public DateTime dataAlteracao { get; set; } = DateTime.Now;
    }
}