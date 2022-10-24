using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMarket.Database;
using MyMarket.Models;

namespace MyMarket.Controllers
{
    public class PedidoController : Controller
    {
        private readonly Context _bancocontext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public PedidoController(Context context, IWebHostEnvironment hostEnvironment)
        {
            _bancocontext = context;
            webHostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            List<DtoPedido> lista = (from p in _bancocontext.pedidos
                                     join c in _bancocontext.produtos on p.produtoid equals c.id
                                     join u in _bancocontext.usuarios on p.usuarioid equals u.id
                                     select new DtoPedido
                                     {
                                         id = p.id,
                                         produto = c.nomeProduto,
                                         usuario = u.nome,
                                         valorTotal = p.valorTotal
                                     }).ToList();

            return View(lista);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _bancocontext.pedidos == null)
            {
                return NotFound();
            }

            var Pedido = await _bancocontext.pedidos
                .FirstOrDefaultAsync(m => m.id == id);
            if (Pedido == null)
            {
                return NotFound();
            }

            return View(Pedido);
        }

        public IActionResult Create()
        {
            ViewBag.Produto2 = new SelectList(_bancocontext.produtos, "id", "nomeProduto");
            ViewBag.Usuario2 = new SelectList(_bancocontext.usuarios, "id", "nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,usuarioid,produtoid,valorTotal")] Pedido Pedido)
        {
            if (ModelState.IsValid)
            {
                _bancocontext.Add(Pedido);
                await _bancocontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Pedido);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Produto2 = new SelectList(_bancocontext.produtos, "id", "nomeProduto");
            ViewBag.Usuario2 = new SelectList(_bancocontext.usuarios, "id", "nome");

            if (id == null || _bancocontext.pedidos == null)
            {
                return NotFound();
            }

            var Produto = await _bancocontext.pedidos.FindAsync(id);
            if (Produto == null)
            {
                return NotFound();
            }
            return View(Produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,usuarioid,produtoid,valorTotal")] Pedido Pedido)
        {
            if (id != Pedido.id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _bancocontext.Update(Pedido);
                await _bancocontext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(Pedido);
        }

        // GET: Chamada/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _bancocontext.pedidos == null)
            {
                return NotFound();
            }

            var Pedido = await _bancocontext.pedidos
                .FirstOrDefaultAsync(m => m.id == id);
            if (Pedido == null)
            {
                return NotFound();
            }

            return View(Pedido);
        }

        // POST: Chamada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_bancocontext.pedidos == null)
            {
                return Problem("Entity set 'Context.Produto'  is null.");
            }
            var Pedido = await _bancocontext.pedidos.FindAsync(id);
            if (Pedido != null)
            {
                _bancocontext.pedidos.Remove(Pedido);
            }

            await _bancocontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
