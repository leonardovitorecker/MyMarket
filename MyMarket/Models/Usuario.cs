using MyMarket.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMarket.Models
{
    public class Usuario
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string email { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public string confirmarSenha { get; set; }
        public string? cpf { get; set; }
        public string telefone { get; set; }
      
        public ICollection<Endereco>? enderecos { get; set; }
        public DateTime dataCadastro { get; set; } = DateTime.Now;
        public DateTime dataAlteracao { get; set; } = DateTime.Now;

        public bool SenhaValida(string senhaUsuario)
        {
            return senha == senhaUsuario;
        }
        public void SetSenhaHash()
        {
            senha = senha.GerarHash();
        }
        public bool IsValidEmail(string email)
        {
            try
            {

                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }

}