using PruebaWTW.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaWTW.Business.Interfaces
{
    public interface IUsuarioBusiness
    {
        Task<Usuario> CrearUsuarioAsync(Usuario usuario);

        Task<IEnumerable<Usuario>> ObtenerUsuariosAsync();

        Task<Usuario> ValidarUsuarioAsync(string usuario, string pass);
    }
}