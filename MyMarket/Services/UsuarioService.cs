using MyMarket.Database;
using MyMarket.Models;

namespace MyMarket.Services
{
    public class UsuarioService: IUsuarioService
    {
        private readonly Context _bancocontext;
        public UsuarioService(Context context)
        {
            _bancocontext = context;
        }

        public List<Usuario> GetUsuarios()
        {
            var users = _bancocontext.usuarios.ToList();
            return users;
        }
    }
}
