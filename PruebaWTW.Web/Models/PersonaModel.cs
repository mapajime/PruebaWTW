using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PruebaWTW.Web.Models
{
    public class PersonaModel
    {
        public int Id { get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        [DisplayName("No Identificacion")]
        public string NumeroIdentificacion { get; set; }

        [Required]
        [DisplayName("Tipo Identificacion")]
        public string TipoIdentificacion { get; set; }

        [Required]
        [DisplayName("Correo eletronico")]

        public string Email { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string IdentificacionTipo { get; set; }

        public string NombreCompleto { get; set; }
    }
}