using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMarket.Database;
using MyMarket.Models;

namespace MyMarket.Controllers
{
    public class LoginController : Controller
    {


        private readonly Context _bancocontext;

        public LoginController(Context context)
        {
            _bancocontext = context;
        }
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }
        public Usuario BuscarLogin(string email)
        {
            return _bancocontext.usuarios.FirstOrDefault(user => user.email == email);

        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoginUsuario loginUsuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = BuscarLogin(loginUsuario.email);
                    loginUsuario.SetSenhaHash();

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginUsuario.senha))
                        {

                            return RedirectToAction("Index", "Home");
                        }
                        else TempData["MensagemErro"] = $"Senha do usuário inválida. Por favor, tente novamente.";
                        return View();
                    }
                    else TempData["MensagemErro"] = $"Usuário ou senha  invalido. Por favor, tente novamente.";
                    return View();
                }

                return RedirectToAction("Index", "Privacy");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamante, detalhe do erro:";
                return RedirectToAction("Entrar");
            }

        }

    }
}
