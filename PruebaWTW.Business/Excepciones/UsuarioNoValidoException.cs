using System;

namespace PruebaWTW.Business.Excepciones
{
    public class UsuarioNoValidoException : Exception
    {
        public UsuarioNoValidoException(string mensaje) : base(mensaje)
        {

        }
    }
}