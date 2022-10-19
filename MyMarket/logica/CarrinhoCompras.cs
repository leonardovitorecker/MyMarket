using Microsoft.AspNetCore.Mvc;
using MyMarket.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace MyMarket.Models
{

    public partial class CarrinhoCompras
    {

        private readonly Context _bancocontext;

        public CarrinhoCompras(Context context)
        {

            _bancocontext = context;

        }

        public CarrinhoCompras()
        {
        }

        string? CarrinhoCompraId { get; set; }
        public const string CarrinhoSessionKey = "CarrinhoId";
        public static CarrinhoCompras GetCarrinho(HttpContext context)
        {
            var carrinho = new CarrinhoCompras();
            carrinho.CarrinhoCompraId = carrinho.GetCarrinhoId(context);
            return carrinho;
        }

        public static CarrinhoCompras GetCarrinho(Controller controller)
        { 
            return GetCarrinho(controller.HttpContext);

        }
        public void AddCarrinho(Produto produto)
        {
            var carrinhoItem = _bancocontext.Carrinhos.SingleOrDefault(
                c => c.CarrinhoId == CarrinhoCompraId
                && c.produtoId == produto.id);

            if (carrinhoItem == null)
            {
                carrinhoItem = new Carrinho
                {
                    produtoId = produto.id,
                    CarrinhoId = CarrinhoCompraId,
                    count = 1,
                    dateCreated = DateTime.Now,
                };
                _bancocontext.Carrinhos.Add(carrinhoItem);
            }
            else
            {
                carrinhoItem.count++;
            }

            _bancocontext.SaveChanges();
        }

        public int RemoverFromCarrinho(int id)
        {
            var carrinhoItem = _bancocontext.Carrinhos.Single(
                carrinho => carrinho.CarrinhoId == CarrinhoCompraId 
                && carrinho.recordId == id);

            int itemCount = 0;

            if(carrinhoItem != null)
            {
                if(carrinhoItem.count > 1)
                {
                    carrinhoItem.count--;
                    itemCount = carrinhoItem.count;
                }
                else
                {
                    _bancocontext.Carrinhos.Remove(carrinhoItem);
                }

                _bancocontext.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCarrinho()
        {
            var carrinhoItems = _bancocontext.Carrinhos.Where(
                carrinho => carrinho.CarrinhoId == CarrinhoCompraId);

            foreach ( var carrinhoItem in carrinhoItems)
            {
                _bancocontext.Carrinhos.Remove(carrinhoItem);
            }
            _bancocontext.SaveChanges();
        }

        public List<Carrinho> GetCarrinhoItens()
        {
            return _bancocontext.Carrinhos.Where(
                carrinho => carrinho.CarrinhoId == CarrinhoCompraId).ToList();
        }

        public int GetCount()
        {
            int? count = (from carrinhoItens in _bancocontext.Carrinhos
                          where carrinhoItens.CarrinhoId == CarrinhoCompraId
                          select (int?)carrinhoItens.count).Sum();

            return count ?? 0;
        }

        public decimal GetTotal()
        {
            decimal total = (from carrinhoItens in _bancocontext.Carrinhos
                             where carrinhoItens.CarrinhoId == CarrinhoCompraId
                             select carrinhoItens.count *
                             carrinhoItens.produto.valorVenda).Sum();

            return total ;
        }

        public int CreatePedido(Pedido pedido)
        {
            decimal pedidoTotal = 0;

            var carrinhoItens = GetCarrinhoItens();

            foreach ( var item in carrinhoItens)
            {
                var pedidoDetalhe = new PedidoDetalhe
                {
                    produtoId = item.produtoId,
                    PedidoId = pedido.pedidoId,
                    UnitPreco = item.produto.valorVenda,
                    quantidade = item.count
                };

                pedidoTotal += (item.count * item.produto.valorVenda);

                _bancocontext.PedidoDetalhes.Add(pedidoDetalhe);
            }
            pedido.valorTotal = pedidoTotal;

            _bancocontext.SaveChanges();
            EmptyCarrinho();

            return pedido.pedidoId;
        }

        public string GetCarrinhoId(HttpContext context)
        {
            var session = "";
            if (context.Session.GetString(CarrinhoSessionKey)== null)
            {
                if(!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    
                    session = context.Session.GetString(CarrinhoSessionKey);
                    session =    context.User.Identity.Name;
                }
                else
                {
                    Guid TempCarrinhoId = Guid.NewGuid();

                    session = TempCarrinhoId.ToString();
                }
            }
            return session;
          
        }
        public void MigrateCarrinho(string userName)
        {
            var CarrinhoCompras = _bancocontext.Carrinhos.Where(
                c => c.CarrinhoId == CarrinhoCompraId);
            
            foreach (Carrinho item in CarrinhoCompras)
            {
                item.CarrinhoId = userName;
            }
            _bancocontext.SaveChanges();
        }
    }
}
