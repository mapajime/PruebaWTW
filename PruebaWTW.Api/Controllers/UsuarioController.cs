using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaWTW.Api.Models;
using PruebaWTW.Business.Excepciones;
using PruebaWTW.Business.Interfaces;
using PruebaWTW.DataAccess.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWTW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioBusiness usuarioBusiness, IMapper mapper)
        {
            _usuarioBusiness = usuarioBusiness;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuarioAsync(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                return BadRequest();
            }
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            try
            {
                var usuarioCreado = await _usuarioBusiness.CrearUsuarioAsync(usuario);
                return Ok(_mapper.Map<UsuarioDTO>(usuarioCreado));
            }
            catch (ArgumentNullException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (UsuarioYaExisteException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error General");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerUsuariosAsync()
        {
            var usuarios = await _usuarioBusiness.ObtenerUsuariosAsync();
            var usuariosDTO = usuarios.Select(u => _mapper.Map<UsuarioDTO>(u));
            return Ok(usuariosDTO);
        }

        [HttpPost("validar")]
        public async Task<IActionResult> ValidarUsuarioAsync(LoginDTO loginDTO)
        {
            if (loginDTO == null)
            {
                return BadRequest();
            }

            try
            {
                var usuario = await _usuarioBusiness.ValidarUsuarioAsync(loginDTO.NombreUsuario, loginDTO.Password);
                return Ok(_mapper.Map<LoginDTO>(usuario));
            }
            catch (UsuarioNoValidoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error General");
            }
        }
    }
}