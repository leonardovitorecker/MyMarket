using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMarket.Database;
using MyMarket.Models;

namespace MyMarket.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly Context _bancocontext;

        public UsuarioController(Context context)
        {
            _bancocontext = context;
        }
        // GET: UsuarioController
        public ActionResult Index()
        {
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
             else   return RedirectToAction("Index","Home");
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
