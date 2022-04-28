using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PruebaWTW.Api.Models;
using PruebaWTW.Business.Interfaces;
using PruebaWTW.DataAccess.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWTW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaBusiness _personaBusiness;
        private readonly IMapper _mapper;

        public PersonaController(IPersonaBusiness personaBusiness, IMapper mapper)
        {
            _personaBusiness = personaBusiness;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CrearPersonaAsync(PersonaDTO personaDTO)
        {
            if (personaDTO == null)
            {
                return BadRequest();
            }
            var persona = await _personaBusiness.CrearPersonaAsync(_mapper.Map<Persona>(personaDTO));
            return Ok(_mapper.Map<PersonaDTO>(persona));
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPersonasAsync()
        {
            var personas = await _personaBusiness.ObtenerPersonasAsync();
            return Ok(personas.Select(p => _mapper.Map<PersonaDTO>(p)));
        }
    }
}