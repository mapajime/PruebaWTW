using System;

namespace PruebaWTW.Business.Excepciones
{
    public class UsuarioYaExisteException : Exception
    {
        public UsuarioYaExisteException(string mensaje) : base(mensaje)
        {
        }
    }
}