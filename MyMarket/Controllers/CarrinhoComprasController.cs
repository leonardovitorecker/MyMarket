﻿
using Microsoft.AspNetCore.Mvc;
using MyMarket.Database;
using MyMarket.Models;
using MyMarket.ViewsModels;

namespace MyMarket.Controllers
{
    public class CarrinhoComprasController : Controller
    {
        private readonly Context _bancocontext;
        
        public CarrinhoComprasController(Context context)
        {

            _bancocontext = context;
          
        }

        public ActionResult Index()
        {
            var carrinho = CarrinhoCompras.GetCarrinho(this.HttpContext, _bancocontext);
            var viewModel = new CarrinhoComprasViewModel
            {
                CartItems = carrinho.GetCarrinhoItens(),
                CarinhoTotal = carrinho.GetTotal()
          };
             return View(viewModel);
        }

        public ActionResult AddCarrinho(int id)
        {
            var addedProduto = _bancocontext.produtos.Single(
                produto => produto.id == id);

            var carrinho = CarrinhoCompras.GetCarrinho(this.HttpContext, _bancocontext);

            carrinho.AddCarrinho(addedProduto);

            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult RemoveCarrinho(int id)
        {
            var carrinho = CarrinhoCompras.GetCarrinho(this.HttpContext, _bancocontext);

            string produtoNome = _bancocontext.carrinhos.Single(
                item => item.recordId == id).produto.nomeProduto;

            int ItemCount = carrinho.RemoverFromCarrinho(id);

            var results = new CarrinhoComprasRemoveViewModel
            {
                Message = System.Web.HttpUtility.HtmlEncode(produtoNome) +
                "Voce deseja remover o carrinho de compras.",
                CarrinhoTotal = carrinho.GetTotal(),
                CarrinhoCount = carrinho.GetCount(),
                ItemCount = ItemCount,
                DeleteId = id
            };
            return Json(results);
        }
    }
   
}
