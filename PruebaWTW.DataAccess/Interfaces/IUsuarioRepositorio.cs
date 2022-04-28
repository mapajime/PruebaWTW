using PruebaWTW.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaWTW.DataAccess.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> CrearUsuarioAsync(Usuario usuario);

        Task ActualizarUsuarioAsync(Usuario usuario);

        Task<Usuario> ValidarUsuarioAsync(string usuario, string pass);
        Task<bool> ExisteUsuarioPorNombreUsuarioAsync(string nombreUsuario);
        Task<IEnumerable<Usuario>> ObtenerUsuariosAsync();

    }
}