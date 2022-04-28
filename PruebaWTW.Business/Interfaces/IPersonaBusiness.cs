using PruebaWTW.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaWTW.Business.Interfaces
{
    public interface IPersonaBusiness 
    {
        Task<Persona> CrearPersonaAsync(Persona persona);
        Task<IEnumerable<Persona>> ObtenerPersonasAsync();
    }
}
