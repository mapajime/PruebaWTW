using Microsoft.EntityFrameworkCore;
using PruebaWTW.DataAccess.Interfaces;
using PruebaWTW.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWTW.DataAccess.Implementaciones
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly PruebaWTWContext _pruebaWTWContext;

        public UsuarioRepositorio(PruebaWTWContext pruebaWTWContext)
        {
            _pruebaWTWContext = pruebaWTWContext;
        }

        public async Task ActualizarUsuarioAsync(Usuario usuario)
        {
            _pruebaWTWContext.Usuarios.Update(usuario);
            await _pruebaWTWContext.SaveChangesAsync();
        }

        public async Task<Usuario> CrearUsuarioAsync(Usuario usuario)
        {
            await _pruebaWTWContext.Usuarios.AddAsync(usuario);
            await _pruebaWTWContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> ValidarUsuarioAsync(string usuario, string pass)
        {
            return await _pruebaWTWContext.Usuarios.Where(u => u.NombreUsuario == usuario && u.Pass == pass).SingleOrDefaultAsync();
        }

        public async Task<bool> ExisteUsuarioPorNombreUsuarioAsync(string nombreUsuario)
        {
            return await _pruebaWTWContext.Usuarios.Where(u => u.NombreUsuario == nombreUsuario).AnyAsync();
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuariosAsync()
        {
            return await _pruebaWTWContext.Usuarios.OrderBy(p=>p.NombreUsuario).ToListAsync();
        }
    }
}