using MyMarket.Models;

namespace MyMarket.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(Usuario usuario);
        void RemoverSessaoUsuario();
        Usuario BuscarSessaoDoUsuario();
        void CriarSessaoDoCarrinho(Carrinho carrinho);
        void RemoverSessaoCarrnho();
        Carrinho BuscarSessaoDoCarrinho();
    }
}
