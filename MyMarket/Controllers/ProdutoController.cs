
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMarket.Database;
using MyMarket.Models;

namespace MyMarket.Controllers
{
    public class ProdutoController : Controller
    {

   
    

        private readonly Context _bancocontext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProdutoController(Context context, IWebHostEnvironment hostEnvironment)
        {
            _bancocontext = context;
            webHostEnvironment = hostEnvironment;
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
                                               arquivo = p.arquivo,
                                               valorVenda = p.valorVenda,
                                               nomecategoria = c.nome,
                                               estoque = p.estoqueAtual
                                           }).ToList();

            return View(lista);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _bancocontext.produtos == null)
            {
                return NotFound();
            }

            var dbProduto = (from p in _bancocontext.produtos
                             join c in _bancocontext.categorias on p.categoriaid equals c.id
                             select new DtoProduto
                             {
                                 id = p.id,
                                 nomeProduto = p.nomeProduto,
                                 imagem = p.imagem,
                                 valorVenda = p.valorVenda,
                                 nomecategoria = c.nome,
                                 estoque = p.estoqueAtual
                             }).FirstOrDefault();
            if (dbProduto == null)
            {
                return NotFound();
            }

            return View(dbProduto);
        }

        public IActionResult Create()
        {
            ViewBag.Categoria1 = new SelectList(_bancocontext.categorias, "id", "nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nomeProduto,imagem,arquivo,estoqueAtual, valorVenda,categoriaid")] Produto Produto, IFormFile arquivo)
        {
            if (ModelState.IsValid)
            {
                IFormFile imagemEnviada = arquivo;
                if (imagemEnviada == null || imagemEnviada.ContentType.ToLower().StartsWith("image/"))
                {
                    MemoryStream ms = new MemoryStream();
                    imagemEnviada.OpenReadStream().CopyTo(ms);
                    Produto.arquivo = ms.ToArray();
                    Produto.imagem = imagemEnviada.FileName;
                    
                }              

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
            var dbProduto = (from p in _bancocontext.produtos
                             join c in _bancocontext.categorias on p.categoriaid equals c.id
                             select new DtoProduto
                             {
                                 id = p.id,
                                 nomeProduto = p.nomeProduto,
                                 imagem = p.imagem,
                                 valorVenda = p.valorVenda,
                                 nomecategoria = c.nome,
                                 estoque = p.estoqueAtual,
                                 categoriaid = p.categoriaid
                             }).FirstOrDefault();

           
            if (dbProduto == null)
            {
                return NotFound();
            }

            return View(Produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nomeProduto,imagem,valorVenda,estoque,nomecategoria, arquivo, categoriaid, dataAlteracao")] Produto Produto)
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

            var dbProduto = (from p in _bancocontext.produtos
                             join c in _bancocontext.categorias on p.categoriaid equals c.id
                             select new DtoProduto
                             {
                                 id = p.id,
                                 nomeProduto = p.nomeProduto,
                                 imagem = p.imagem,
                                 valorVenda = p.valorVenda,
                                 nomecategoria = c.nome,
                                 estoque = p.estoqueAtual
                             }).FirstOrDefault();
            if (dbProduto == null)
            {
                return NotFound();
            }

            return View(dbProduto);
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
