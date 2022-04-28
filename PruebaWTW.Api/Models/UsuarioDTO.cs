using System;

namespace PruebaWTW.Api.Models
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Pass { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}