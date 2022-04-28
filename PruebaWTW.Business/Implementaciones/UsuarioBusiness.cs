using PruebaWTW.Business.Excepciones;
using PruebaWTW.Business.Interfaces;
using PruebaWTW.DataAccess.Interfaces;
using PruebaWTW.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaWTW.Business.Implementaciones
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioBusiness(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<Usuario> CrearUsuarioAsync(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "El usuario es nulo");
            }
            if (string.IsNullOrEmpty(usuario.NombreUsuario))
            {
                throw new ArgumentException("El nombre del usuario esta vacio");
            }
            if (await _usuarioRepositorio.ExisteUsuarioPorNombreUsuarioAsync(usuario.NombreUsuario))
            {
                throw new UsuarioYaExisteException($"El usuario '{usuario.NombreUsuario}' ya existe");
            }
            usuario.FechaCreacion = DateTime.Now;
            return await _usuarioRepositorio.CrearUsuarioAsync(usuario);
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuariosAsync()
        {
            return await _usuarioRepositorio.ObtenerUsuariosAsync();
        }

        public async Task<Usuario> ValidarUsuarioAsync(string usuario, string pass)
        {
            var usuarioAValidar = await _usuarioRepositorio.ValidarUsuarioAsync(usuario, pass);
            if (usuarioAValidar == null)
            {
                throw new UsuarioNoValidoException("Credenciales invalidas");
            }
            return usuarioAValidar;
        }
    }
}