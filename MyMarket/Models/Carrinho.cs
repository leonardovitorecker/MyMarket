using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMarket.Models
{
    public class Carrinho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int recordId { get; set; }
        public string CarrinhoId { get; set; }
        public int produtoId { get; set; }
        public  int count { get; set; } 
        public System.DateTime dateCreated { get; set; }
        public virtual Produto produto { get; set; }
    }
}
