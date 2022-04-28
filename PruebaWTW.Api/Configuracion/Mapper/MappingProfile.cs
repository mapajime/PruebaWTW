using AutoMapper;
using PruebaWTW.Api.Models;
using PruebaWTW.DataAccess.Models;

namespace PruebaWTW.Api.Configuracion.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Persona, PersonaDTO>();
            CreateMap<PersonaDTO, Persona>();

            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<Usuario, UsuarioDTO>();

            CreateMap<LoginDTO, Usuario>();
            CreateMap<Usuario, LoginDTO>();
        }
    }
}