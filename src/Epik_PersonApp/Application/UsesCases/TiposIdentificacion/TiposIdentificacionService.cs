using AutoMapper;
using Epik_PersonApp.Application.Dtos.TiposIdentificacion;
using Epik_PersonApp.Application.Interfaces.Persistence;
using Epik_PersonApp.Application.Interfaces.Services;
using Epik_PersonApp.Application.UsesCases.Personas;
using Epik_PersonApp.Common;

namespace Epik_PersonApp.Application.UsesCases.TiposIdentificacion
{
    public class TiposIdentificacionService : ITipoIdentificacionService
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly IMapper? _mapper;
        private readonly ILogger<PersonaService>? _logger;

        public TiposIdentificacionService(IUnitOfWork? unitOfWork, IMapper? mapper, ILogger<PersonaService>? logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseAPI<IEnumerable<ObtenerTodosTipoIdentificacionDto>>> ObtenerTodosTiposIdentificacion()
        {
            const string? methodName = nameof(ObtenerTodosTiposIdentificacion);
            var tiposIdentificacion = await _unitOfWork!.TiposIdentificacion.ObtenerTodos(orderBy: q => q.OrderBy(ti => ti.Codigo), isTracking: false);

            if (tiposIdentificacion.Any())
            {
                _logger!.LogInformation("{MethodName}: Obteniendo tipos de identificación exitosamente", methodName);

                var personasList = _mapper!.Map<IEnumerable<ObtenerTodosTipoIdentificacionDto>>(tiposIdentificacion);

                return new ResponseAPI<IEnumerable<ObtenerTodosTipoIdentificacionDto>>
                {
                    Data = personasList,
                    IsSuccess = true,
                    Message = "Obteniendo todos los tipos de identificación."
                };
            }
            else
            {

                _logger!.LogInformation("{MethodName}: Ningún tipo de identificación fue encontrado", methodName);

                return new ResponseAPI<IEnumerable<ObtenerTodosTipoIdentificacionDto>>
                {
                    Data = Enumerable.Empty<ObtenerTodosTipoIdentificacionDto>(),
                    IsSuccess = true,
                    Message = " Ningún tipo de identificación fue encontrado."
                };
            }
        }
    }
}
