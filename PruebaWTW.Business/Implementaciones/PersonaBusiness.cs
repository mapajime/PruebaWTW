using PruebaWTW.Business.Interfaces;
using PruebaWTW.DataAccess.Interfaces;
using PruebaWTW.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaWTW.Business.Implementaciones
{
    public class PersonaBusiness : IPersonaBusiness
    {
        private readonly IPersonaRepositorio _personaRepositorio;

        public PersonaBusiness(IPersonaRepositorio personaRepositorio)
        {
            _personaRepositorio = personaRepositorio;
        }

        public async Task<Persona> CrearPersonaAsync(Persona persona)
        {
            if (persona == null)
            {
                throw new ArgumentNullException(nameof(persona), "La persona es nula");
            }
            if (string.IsNullOrEmpty(persona.Nombres))
            {
                throw new ArgumentNullException(nameof(persona.Nombres), "El nombre es nulo");
            }
            if (string.IsNullOrEmpty(persona.Apellidos))
            {
                throw new ArgumentNullException(nameof(persona.Apellidos), "Los apellidos son nulos");
            }
            persona.FechaCreacion = DateTime.Now;
            //persona.NombreCompleto = $"{persona.Nombres}-{persona.Apellidos}";
            //persona.TipoIdentificacion = persona.NumeroIdentificacion + "-" + persona.TipoIdentificacion;
            return await _personaRepositorio.CrearPersonaAsync(persona);
        }

        public async Task<IEnumerable<Persona>> ObtenerPersonasAsync()
        {
            return await _personaRepositorio.ObtenerPersonaPorNombreCompletoAsync(null);
        }
    }
}