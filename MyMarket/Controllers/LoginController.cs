using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMarket.Database;
using MyMarket.Helper;
using MyMarket.Models;

namespace MyMarket.Controllers
{
    public class LoginController : Controller
    {


        private readonly Context _bancocontext;
        private readonly ISessao _sessao;
        public LoginController(Context context, ISessao sessao)
        {
            _bancocontext = context;
            _sessao = sessao;
        }
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index", "Login");

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
                    

                    if (usuario != null)
                    {
                        loginUsuario.SetSenhaHash();
                        if (usuario.SenhaValida(loginUsuario.senha))
                        {
                           
                            return RedirectToAction("Index", "Home");
                        }
                        else TempData["MensagemErro"] = $"Senha do usuário inválida. Por favor, tente novamente.";
                        return RedirectToAction("Create", "Login");
                    }
                    else TempData["MensagemErro"] = $"Usuário ou senha  invalido. Por favor, tente novamente.";
                    return RedirectToAction("Create", "Login");
                }

                return RedirectToAction("Create", "Login");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamante, detalhe do erro:";
                return RedirectToAction("Create", "Login");
            }

        }

    }
}
