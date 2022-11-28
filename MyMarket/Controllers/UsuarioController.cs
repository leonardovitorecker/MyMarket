using FastReport.Export.PdfSimple;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMarket.Database;
using MyMarket.Helper;
using MyMarket.Models;
using MyMarket.Services;

namespace MyMarket.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly Context _bancocontext;
        private readonly ISessao _sessao;
        private readonly IWebHostEnvironment _webHostEnv;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(Context context, ISessao sessao, IWebHostEnvironment webHostEnv,
            IUsuarioService usuarioService)
        {
            _sessao = sessao;
            _bancocontext = context;
            _webHostEnv = webHostEnv;
            _usuarioService = usuarioService;
        }
        // GET: UsuarioController
        public async Task<IActionResult> Index()
        {
            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");
            List<DtoUsuario> lista = (from u in _bancocontext.usuarios
                                      select new DtoUsuario
                                      {
                                          id = u.id,
                                          email = u.email,
                                          cpf = u.cpf,
                                          nome = u.nome,

                                          telefone = u.telefone
                                      }).ToList();


            return View(lista);


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
                        else TempData["MensagemErro"] = $"Email nao é valido";
                        return RedirectToAction("Create", "Usuario");
                    }
                    TempData["MensagemErro"] = $"Username ja existe";
                    return RedirectToAction("Create", "Usuario");
                }
                else return RedirectToAction("Create");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu cadastro, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Create");
            }
        }
        [Route("CreateReportUser")]
        public IActionResult CreateReportUser()
        {
            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\ReportMvcUser.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var usuarioList = _usuarioService.GetUsuarios();

            freport.Dictionary.RegisterBusinessObject(usuarioList, "usuarioList", 10, true);
            freport.Report.Save(reportFile);

            return Ok($" Relatorio gerado : {caminhoReport}");
        }
        [Route("UsuarioReport")]
        public IActionResult UsuarioReport()
        {
            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\ReportMvcUser.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var usuarioList = _usuarioService.GetUsuarios();

            freport.Report.Load(reportFile);
            freport.Dictionary.RegisterBusinessObject(usuarioList, "usuarioList", 10, true);
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
