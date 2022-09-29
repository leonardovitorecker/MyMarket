using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMarket.Database;
using MyMarket.Models;

namespace MyMarket.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly Context _bancocontext;
       
        public ProdutoController(Context context)
        {
            _bancocontext = context;
            
        }
        // GET: ProdutoController
   


        public async Task<IActionResult> Index(string searchstring)
        {

            var produto = (from p in _bancocontext.produtos
                           join e in _bancocontext.estoques on p.estoqueid equals e.id
                           select new DtoProduto
                           {
                               id = p.id,
                               nomeProduto = p.nomeProduto,
                               valorVenda = p.valorVenda,
                               estoque = e.estoqueAtual
                           });

            if (!String.IsNullOrEmpty(searchstring))
            {
                produto = produto.Where(s => s.nomeProduto.Contains(searchstring));
            }

            return View(await produto.ToListAsync());
        }

    }
}
