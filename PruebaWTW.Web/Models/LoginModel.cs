using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PruebaWTW.Web.Models
{
    public class LoginModel
    {
        [Required]
        [DisplayName("Nombre Usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [DisplayName("Contraseña")]
        public string Password { get; set; }
    }
}