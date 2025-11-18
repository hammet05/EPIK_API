using AutoMapper;
using Epik_PersonApp.Application.Dtos.Generos;
using Epik_PersonApp.Application.Dtos.Personas;
using Epik_PersonApp.Application.Dtos.TiposIdentificacion;
using Epik_PersonApp.Domain.Entities;

namespace Epik_PersonApp.Application.UsesCases.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CrearPersonaDto, Persona>().ForMember(dest => dest.TipoIdentificacion, opt => opt.Ignore());

            CreateMap<Persona, ObtenerTodasPersonasDto>().ForMember(dest => dest.TipoIdentificacion,
                                                                    opt => opt.MapFrom(src => src.TipoIdentificacion != null ? src.TipoIdentificacion.Descripcion : null)
                                                                    )
                                                         .ForMember(dest => dest.GeneroPersona,
                                                                    opt => opt.MapFrom(src => src.Genero != null ? src.Genero.Descripcion : null)
                                                                        );
            CreateMap<Persona, BuscarPersonaPorIdentificacionDto>().ForMember(dest => dest.TipoIdentificacion,
                                                                              opt => opt.MapFrom(src => src.TipoIdentificacion != null ? src.TipoIdentificacion.Descripcion : null)
                                                                             );


            CreateMap<CrearPersonaDto, Persona>().ForMember(dest => dest.TipoIdentificacion, opt => opt.Ignore());

            CreateMap<PersonalFemenino, PersonalFemeninoDto>();

            CreateMap<TipoIdentificacion, ObtenerTodosTipoIdentificacionDto>();
            CreateMap<Genero, ObtenerGenerosDto>();
        }

    }
}
