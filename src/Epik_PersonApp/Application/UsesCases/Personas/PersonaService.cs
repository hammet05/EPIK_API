using AutoMapper;
using Epik_PersonApp.Application.Dtos.Personas;
using Epik_PersonApp.Application.Interfaces.Persistence;
using Epik_PersonApp.Application.Interfaces.Services;
using Epik_PersonApp.Common;
using Epik_PersonApp.Domain.Entities;

namespace Epik_PersonApp.Application.UsesCases.Personas
{
    public class PersonaService : IPersonaService
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly IMapper? _mapper;
        private readonly ILogger<PersonaService>? _logger;

        public PersonaService(IUnitOfWork? unitOfWork, IMapper? mapper, ILogger<PersonaService>? logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }



        public async Task<ResponseAPI<BuscarPersonaPorIdentificacionDto>> BuscarPersonaPorIdentificacion(string numeroIdentificacion)
        {
            const string? methodName = nameof(BuscarPersonaPorIdentificacion);
            try
            {
                var personaEncontrada = await _unitOfWork!.Personas.ObtenerPrimero(filter: p => p.Identificacion == numeroIdentificacion,
                                                                isTracking: false,
                                                                includeProperties: "TipoIdentificacion");


                if (string.IsNullOrEmpty(personaEncontrada.Identificacion))
                {
                    return new ResponseAPI<BuscarPersonaPorIdentificacionDto>
                    {
                        IsSuccess = false,
                        Message = $"Nimguna persona fue encontrada con el número de identificación:: {numeroIdentificacion}.",
                        Data = new BuscarPersonaPorIdentificacionDto()
                    };
                }

                var employee = _mapper!.Map<BuscarPersonaPorIdentificacionDto>(personaEncontrada);


                return new ResponseAPI<BuscarPersonaPorIdentificacionDto>
                {
                    Data = employee,
                    IsSuccess = true,
                    Message = $"Persona encontrada exitosamente:: {numeroIdentificacion}",

                };
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, $"Error in {methodName}");

                return new ResponseAPI<BuscarPersonaPorIdentificacionDto>
                {
                    IsSuccess = false,
                    Message = "Ocurrio un error al tratar de buscar una persona.",
                    Data = new BuscarPersonaPorIdentificacionDto()
                };
            }
        }

        public async Task<ResponseAPI<bool>> Crear(CrearPersonaDto crearPersonaDto)
        {
            const string? methodName = nameof(Crear);

            try
            {
                var conteoPersona = await _unitOfWork!.Personas.ContarPersonaPorIdentificacion(crearPersonaDto.Identificacion!);


                if (conteoPersona >= 1)
                    return (
                        new ResponseAPI<bool>
                        {
                            Data = false,
                            IsSuccess = false,
                            Message = "La persona ya está registrada"
                        });


                var nuevaPersona = _mapper!.Map<Persona>(crearPersonaDto);

                await _unitOfWork!.Personas.Crear(nuevaPersona);
                await _unitOfWork.SaveChangesAsync();


                return new ResponseAPI<bool>
                {
                    Data = true,
                    IsSuccess = true,
                    Message = "Persona creada exitosamente."
                };

            }
            catch (Exception ex)
            {

                _logger?.LogError(ex, $"Hubo un error al tratar de crear una persona en {methodName}");
                return new ResponseAPI<bool>
                {
                    Data = false,
                    IsSuccess = false,
                    Message = "Hubo un error al crear una persona."
                };
            }
        }

        public async Task<ResponseAPI<IEnumerable<PersonalFemeninoDto>>> ObtenerPersonalFemenino()
        {
            const string? methodName = nameof(ObtenerPersonalFemenino);
            var personalFemeninoList = await _unitOfWork!.Personas.ObtenerPersonalFemeninoAsync();

            if (personalFemeninoList.Any())
            {
                _logger!.LogInformation("{MethodName}: Obteniendo todo el personal femenino exitosamente", methodName);

                var mujeresList = _mapper!.Map<IEnumerable<PersonalFemeninoDto>>(personalFemeninoList);

                return new ResponseAPI<IEnumerable<PersonalFemeninoDto>>
                {
                    Data = mujeresList,
                    IsSuccess = true,
                    Message = "Obteniendo todo el personal femenino exitosamente."
                };
            }
            else
            {

                _logger!.LogInformation("{MethodName}: Ninguna mujer fue encontrada", methodName);

                return new ResponseAPI<IEnumerable<PersonalFemeninoDto>>
                {
                    Data = Enumerable.Empty<PersonalFemeninoDto>(),
                    IsSuccess = true,
                    Message = "Ninguna mujer fue encontrada."
                };
            }
        }

        public async Task<ResponseAPI<IEnumerable<ObtenerTodasPersonasDto>>> ObtenerTodasPersona()
        {
            const string? methodName = nameof(ObtenerTodasPersona);
            var personas = await _unitOfWork!.Personas.ObtenerTodos(orderBy: q => q.OrderBy(p => p.Nombres),
                                                                includeProperties: "TipoIdentificacion,Genero", isTracking: false);

            if (personas.Any())
            {
                _logger!.LogInformation("{MethodName}: Obteniendo todas las personas exitosamente", methodName);

                var personasList = _mapper!.Map<IEnumerable<ObtenerTodasPersonasDto>>(personas);

                return new ResponseAPI<IEnumerable<ObtenerTodasPersonasDto>>
                {
                    Data = personasList,
                    IsSuccess = true,
                    Message = "All employees retrieved successfully."
                };
            }
            else
            {

                _logger!.LogInformation("{MethodName}: Ninguna persona fue encontrada", methodName);

                return new ResponseAPI<IEnumerable<ObtenerTodasPersonasDto>>
                {
                    Data = Enumerable.Empty<ObtenerTodasPersonasDto>(),
                    IsSuccess = true,
                    Message = "Ninguna persona fue encontrada."
                };
            }
        }

        public async Task<ResponseAPI<bool>> ActualizarEdad(string numeroIdentificacion, int edad)
        {
            const string? methodName = nameof(ActualizarEdad);

            try
            {
                var edadPersonaActualizada = await _unitOfWork!.Personas!.ActualizarEdadPersona(numeroIdentificacion, edad);
                if (!edadPersonaActualizada)
                {
                    return new ResponseAPI<bool>
                    {
                        Data = false,
                        IsSuccess = false,
                        Message = "No se encontró la persona o no se pudo actualizar."
                    };
                }

                return new ResponseAPI<bool>
                {
                    Data = true,
                    IsSuccess = true,
                    Message = "Edad actualizada correctamente."
                };

            }
            catch (Exception ex)
            {

                _logger?.LogError(ex, $"No se encontró la persona o no se pudo actualizar {methodName}");
                return new ResponseAPI<bool>
                {
                    Data = false,
                    IsSuccess = false,
                    Message = "No se encontró la persona o no se pudo actualizar."
                };
            }
        }

        public async Task<ResponseAPI<bool>> CambiarEstadoPersona(string numeroIdentificacion, bool estado)
        {
            const string? methodName = nameof(CambiarEstadoPersona);

            try
            {
                var cambioEstadoActualizado = await _unitOfWork!.Personas!.CambiarEstadoPersona(numeroIdentificacion, estado);

                if (!cambioEstadoActualizado)
                {
                    return new ResponseAPI<bool>
                    {
                        Data = false,
                        IsSuccess = false,
                        Message = "No se encontró la persona o no se pudo actualizar su estado."
                    };
                }

                return new ResponseAPI<bool>
                {
                    Data = true,
                    IsSuccess = true,
                    Message = "Estado actualizada correctamente."
                };

            }
            catch (Exception ex)
            {

                _logger?.LogError(ex, $"No se encontró la persona o no se pudo actualizar su estado {methodName}");
                return new ResponseAPI<bool>
                {
                    Data = false,
                    IsSuccess = false,
                    Message = "No se encontró la persona o no se pudo actualizar su estado."
                };
            }
        }

        public async Task<ResponseAPI<bool>> EliminarPersona(string numeroIdentificacion)
        {
            const string? methodName = nameof(EliminarPersona);

            try
            {
                await _unitOfWork!.Personas!.EliminarPersona(numeroIdentificacion);

                return new ResponseAPI<bool>
                {
                    Data = true,
                    IsSuccess = true,
                    Message = "Persona eliminada correctamente."
                };

            }
            catch (Exception ex)
            {

                _logger?.LogError(ex, $"No se encontró la persona para eliminar {methodName}");
                return new ResponseAPI<bool>
                {
                    Data = false,
                    IsSuccess = false,
                    Message = "No se encontró la persona o no se pudo eliminar."
                };
            }
        }
    }
}
