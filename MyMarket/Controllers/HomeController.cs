using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMarket.Database;
using MyMarket.Models;
using System.Diagnostics;

namespace MyMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _bancocontext;
        
       

        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _bancocontext = context;
        }

        public async Task<IActionResult> Index(string searchstring)
        {

            var produto = (from p in _bancocontext.produtos
                           select new DtoProduto
                           {
                               id = p.id,
                               nomeProduto = p.nomeProduto,
                               valorVenda = p.valorVenda,
                               imagem = p.imagem,
                           });

            if (!String.IsNullOrEmpty(searchstring))
            {
                produto = produto.Where(s => s.nomeProduto.Contains(searchstring));
            }

            return View(await produto.ToListAsync());
        }
        [HttpGet]
     
        public async Task<IActionResult> ProdutoExpandido(int? id)
        {
            if (id == null || _bancocontext.produtos == null)
            {
                return NotFound();
            }

            var Produto = await _bancocontext.produtos
                .FirstOrDefaultAsync(m => m.id == id);
            if (Produto == null)
            {
                return NotFound();
            }

            return View(Produto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

  

    }
}