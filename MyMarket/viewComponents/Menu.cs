
using Microsoft.AspNetCore.Mvc;
using MyMarket.Models;
using Newtonsoft.Json;
namespace MyMarket.viewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

           
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);

            return View(usuario);
        }
    }
}
