using Microsoft.EntityFrameworkCore;
using PruebaWTW.DataAccess.Interfaces;
using PruebaWTW.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWTW.DataAccess.Implementaciones
{
    public class PersonaRepositorio : IPersonaRepositorio
    {
        private readonly PruebaWTWContext _pruebaWTWContext;

        public PersonaRepositorio(PruebaWTWContext pruebaWTWContext)
        {
            _pruebaWTWContext = pruebaWTWContext;
        }

        public async Task ActualizarPersonaAsync(Persona persona)
        {
            _pruebaWTWContext.Update(persona);
            await _pruebaWTWContext.SaveChangesAsync();
        }

        public async Task<Persona> CrearPersonaAsync(Persona persona)
        {
            await _pruebaWTWContext.Personas.AddAsync(persona);
            await _pruebaWTWContext.SaveChangesAsync();
            return persona;
        }

        public async Task EliminarPersonaAsync(int id)
        {
            var persona = _pruebaWTWContext.Personas.Where(p => p.Id == id).SingleOrDefault();
            if (persona != null)
            {
                _pruebaWTWContext.Personas.Remove(persona);
                await _pruebaWTWContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Persona>> ObtenerPersonaPorNombreCompletoAsync(string nombreCompleto)
        {
            if (string.IsNullOrEmpty(nombreCompleto))
            {
                return await _pruebaWTWContext.Personas.ToListAsync();
            }

            return await _pruebaWTWContext.Personas.Where(p => p.NombreCompleto.Contains(nombreCompleto)).ToListAsync();
        }
    }
}