using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PruebaWTW.Web.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Nombre usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [DisplayName("Contraseña")]
        public string Pass { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}