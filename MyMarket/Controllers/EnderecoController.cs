using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyMarket.Controllers
{
    public class EnderecoController : Controller
    {
        // GET: EnderecoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EnderecoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EnderecoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnderecoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: EnderecoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EnderecoController/Edit/5
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

        // GET: EnderecoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EnderecoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
