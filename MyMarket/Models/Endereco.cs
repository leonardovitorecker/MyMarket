using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMarket.Models
{
    public class Endereco
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string cidade { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string rua { get; set; }
        public int numeroCasa { get; set; }
        public string? complemento { get; set; }
        public int usuarioid { get; set; }
        public DateTime dataAlteracao { get; set; } = DateTime.Now;
    }
}
