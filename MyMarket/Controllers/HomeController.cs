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
                              
                           });

            if (!String.IsNullOrEmpty(searchstring))
            {
                produto = produto.Where(s => s.nomeProduto.Contains(searchstring));
            }

            return View(await produto.ToListAsync());
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