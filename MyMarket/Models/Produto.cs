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
        public byte[]? arquivo { get; set; }
        public string? imagem { get; set; }
        public decimal valorVenda { get; set; }
        public Estoque estoque { get; set; }

        public int estoqueid {get;set;}
        public Categoria categoria { get; set; }

        public int categoriaid { get; set; }
        public DateTime dataCadastro { get; set; } = DateTime.Now;
        public DateTime dataAlteracao { get; set; } = DateTime.Now;
    }
}