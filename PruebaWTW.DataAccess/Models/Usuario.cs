using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaWTW.DataAccess.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Pass { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
