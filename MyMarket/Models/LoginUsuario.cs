using MyMarket.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMarket.Models
{
    public class LoginUsuario
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string email { get; set; }
        public string senha { get; set; }

        public void SetSenhaHash()
        {
            senha = senha.GerarHash();
        }
    }
}
