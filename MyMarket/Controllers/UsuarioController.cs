using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMarket.Database;
using MyMarket.Helper;
using MyMarket.Models;

namespace MyMarket.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly Context _bancocontext;
        private readonly ISessao _sessao;

        public UsuarioController(Context context, ISessao sessao)
        {
            _sessao = sessao;
            _bancocontext = context;
        }
        // GET: UsuarioController
        public ActionResult Index()
        {
            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }
   
        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var verificaEmail = _bancocontext.usuarios.FirstOrDefault(user => user.email == usuario.email);
                  

                    if (verificaEmail == null)
                    {
                        if (usuario.IsValidEmail(usuario.email) == true)
                        {
                            if (usuario.senha == usuario.confirmarSenha)
                            {
                                usuario.SetSenhaHash();

                                _bancocontext.usuarios.Add(usuario);
                                _bancocontext.SaveChanges();
                                _sessao.CriarSessaoDoUsuario(usuario);
                                return RedirectToAction("Index", "Home");
                            }
                            else TempData["MensagemErro"] = $"Senhas não coicidem";
                            return RedirectToAction("Create", "Usuario");
                        }
                            else  TempData["MensagemErro"] = $"Email nao é valido";
                        return RedirectToAction("Create", "Usuario");
                    }
                         TempData["MensagemErro"] = $"Username ja existe";
                    return RedirectToAction("Create", "Usuario");
                }
             else   return RedirectToAction("Create");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu cadastro, tente novamante, detalhe do erro: {erro.Message}";
              return  RedirectToAction("Create");
            }
        }

    

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

   
        
    }
}
