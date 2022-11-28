using MyMarket.Database;
using MyMarket.Models;

namespace MyMarket.Services
{
    public class ProductService : IProductService
    {
        private readonly Context _bancocontext;
        public ProductService(Context context)
        {
            _bancocontext = context;
        }

        public List<Produto> GetProducts()
        {
            var products = _bancocontext.produtos.ToList();
            return products;
        }
    }
}
