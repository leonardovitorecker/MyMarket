using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMarket.Database;
using MyMarket.Models;
using MyMarket.Services;
using FastReport.Export.PdfSimple;
using System.Diagnostics;

namespace MyMarket.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly Context _bancocontext;
        private readonly IWebHostEnvironment _webHostEnv;
        private readonly IProductService _productService;
        public ProdutoController(Context context, IWebHostEnvironment webHostEnv,
             IProductService productService)
        {
            _bancocontext = context;
            _webHostEnv = webHostEnv;
            _productService = productService;
        }

        // GET: Chamada
        public async Task<IActionResult> Index()
        {
            List<DtoProduto> lista = (from p in _bancocontext.produtos
                                      join c in _bancocontext.categorias on p.categoriaid equals c.id
                                      select new DtoProduto
                                      {
                                          id = p.id,
                                          nomeProduto = p.nomeProduto,
                                          valorVenda = p.valorVenda,
                                          categoria = c.nome,
                                          estoque = p.estoque
                                      }).ToList();

            return View(lista);
        }
        [Route("CreateReport")]
        public IActionResult CreateReport()
        {
            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\ReportMvc.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var productList = _productService.GetProducts();

            freport.Dictionary.RegisterBusinessObject(productList, "productList", 10, true);
            freport.Report.Save(reportFile);

            return Ok($" Relatorio gerado : {caminhoReport}");
        }
        [Route("ProductsReport")]
        public IActionResult ProductsReport()
        {
            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\ReportMvc.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var productList = _productService.GetProducts();

            freport.Report.Load(reportFile);
            freport.Dictionary.RegisterBusinessObject(productList, "productList", 10, true);
            //freport.Report.Save(reportFile);
            freport.Prepare();

            var pdfExport = new PDFSimpleExport();

            using MemoryStream ms = new MemoryStream();
            pdfExport.Export(freport, ms);
            ms.Flush();

            return File(ms.ToArray(), "application/pdf");
            //return Ok($"Relatorio gerado: {caminhoReport}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> Details(int? id)
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

        public IActionResult Create()
        {
            ViewBag.Categoria2 = new SelectList(_bancocontext.categorias, "id", "nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nomeProduto,estoque,valorVenda,categoriaid")] Produto Produto)
         {
            if (ModelState.IsValid)
            {
               
                
                _bancocontext.Add(Produto);
                await _bancocontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Produto);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Categoria2 = new SelectList(_bancocontext.categorias, "id", "nome");
            if (id == null || _bancocontext.produtos == null)
            {
                return NotFound();
            }

            var Produto = await _bancocontext.produtos.FindAsync(id);
            if (Produto == null)
            {
                return NotFound();
            }
            return View(Produto);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nomeProduto,estoque,valorVenda,categoriaid")] Produto Produto)
        {
            if (id != Produto.id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _bancocontext.Update(Produto);
                    await _bancocontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(Produto.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Produto);
        }

        // GET: Chamada/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Chamada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_bancocontext.produtos == null)
            {
                return Problem("Entity set 'Context.Produto'  is null.");
            }
            var Produto = await _bancocontext.produtos.FindAsync(id);
            if (Produto != null)
            {
                _bancocontext.produtos.Remove(Produto);
            }

            await _bancocontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return (_bancocontext.produtos?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
