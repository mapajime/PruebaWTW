using System;

#nullable disable

namespace PruebaWTW.DataAccess.Models
{
    public partial class Persona
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string IdentificacionTipo { get; set; }
        public string NombreCompleto { get; set; }
    }
}