using MyMarket.Models;

namespace MyMarket.ViewsModels
{
    public class CarrinhoComprasViewModel
    {
        public List<Carrinho> CartItems { get; set; }
        public decimal CarinhoTotal { get; set; }
    }
}
