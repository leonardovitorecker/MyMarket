using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMarket.Database;
using MyMarket.Models;

namespace MyMarket.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly Context _bancocontext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public EstoqueController(Context context, IWebHostEnvironment hostEnvironment)
        {
            _bancocontext = context;
            webHostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            List<DtoEstoque> lista = (from e in _bancocontext.estoques
                                      join p in _bancocontext.produtos on e.produtoid equals p.id
                                      select new DtoEstoque
                                      {
                                          id = e.id,
                                          estoqueAtual = e.estoqueAtual,
                                          nomeProduto = p.nomeProduto
                                      }).ToList();

            return View(lista);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _bancocontext.estoques == null)
            {
                return NotFound();
            }

            var Estoque = await _bancocontext.estoques
                .FirstOrDefaultAsync(m => m.id == id);
            if (Estoque == null)
            {
                return NotFound();
            }

            return View(Estoque);
        }

        public IActionResult Create()
        {
            ViewBag.Produto2 = new SelectList(_bancocontext.produtos, "id", "nomeProduto");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,estoqueAtual,produtoid")] Estoque Estoque)
        {
            if (ModelState.IsValid)
            {
                _bancocontext.Add(Estoque);
                await _bancocontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Estoque);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Produto2 = new SelectList(_bancocontext.produtos, "id", "nomeProduto");
            if (id == null || _bancocontext.estoques == null)
            {
                return NotFound();
            }

            var Estoque = await _bancocontext.estoques.FindAsync(id);
            if (Estoque == null)
            {
                return NotFound();
            }
            return View(Estoque);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,estoqueAtual,produtoid")] Estoque Estoque)
        {
            if (id != Estoque.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bancocontext.Update(Estoque);
                    await _bancocontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstoqueExists(Estoque.id))
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
            return View(Estoque);
        }

        private bool EstoqueExists(int id)
        {
            return (_bancocontext.estoques?.Any(e => e.id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _bancocontext.estoques == null)
            {
                return NotFound();
            }

            var Estoque = await _bancocontext.estoques
                .FirstOrDefaultAsync(m => m.id == id);
            if (Estoque == null)
            {
                return NotFound();
            }

            return View(Estoque);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_bancocontext.estoques == null)
            {
                return Problem("Entity set 'Context.Produto'  is null.");
            }
            var Estoque = await _bancocontext.estoques.FindAsync(id);
            if (Estoque != null)
            {
                _bancocontext.estoques.Remove(Estoque);
            }

            await _bancocontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
