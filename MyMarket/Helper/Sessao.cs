using Microsoft.AspNetCore.Http;
using MyMarket.Models;
using Newtonsoft.Json;

namespace MyMarket.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;
        
        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public Carrinho BuscarSessaoDoCarrinho()
        {
            string sessaoCarrinho = _httpContext.HttpContext.Session.GetString("sessaoCarrinho");

            if (!string.IsNullOrEmpty(sessaoCarrinho)) return null;

            return JsonConvert.DeserializeObject<Carrinho>(sessaoCarrinho);
        }

        public Usuario BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");
            

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);
        }

        public void CriarSessaoDoCarrinho(Carrinho carrinho)
        {
           string valor = JsonConvert.SerializeObject(carrinho);
            _httpContext.HttpContext.Session.SetString("sessaoCarrinho", valor);
        }

        public void CriarSessaoDoUsuario(Usuario usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);

            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoCarrnho()
        {
            _httpContext.HttpContext.Session.Remove("sessaoCarrinho");
        }

        public void RemoverSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }

      

       
    }
}
