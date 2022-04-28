using PruebaWTW.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaWTW.DataAccess.Interfaces
{
    public interface IPersonaRepositorio
    {
        Task<Persona> CrearPersonaAsync(Persona persona);

        Task ActualizarPersonaAsync(Persona persona);

        Task<IEnumerable<Persona>> ObtenerPersonaPorNombreCompletoAsync(string nombreCompleto);

        Task EliminarPersonaAsync(int id);
    }
}