using AutoMapper;
using Epik_PersonApp.Application.Dtos.Generos;
using Epik_PersonApp.Application.Interfaces.Persistence;
using Epik_PersonApp.Application.Interfaces.Services;
using Epik_PersonApp.Application.UsesCases.Personas;
using Epik_PersonApp.Common;

namespace Epik_PersonApp.Application.UsesCases.Generos
{
    public class GenerosService : IGeneroService
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly IMapper? _mapper;
        private readonly ILogger<PersonaService>? _logger;

        public GenerosService(IUnitOfWork? unitOfWork, IMapper? mapper, ILogger<PersonaService>? logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseAPI<IEnumerable<ObtenerGenerosDto>>> ObtenerGeneros()
        {
            const string? methodName = nameof(ObtenerGeneros);
            var personas = await _unitOfWork!.Generos.ObtenerTodos(orderBy: q => q.OrderBy(g => g.Descripcion), isTracking: false);


            if (personas.Any())
            {
                _logger!.LogInformation("{MethodName}: Obteniendo todos los generos exitosamente", methodName);

                var personasList = _mapper!.Map<IEnumerable<ObtenerGenerosDto>>(personas);

                return new ResponseAPI<IEnumerable<ObtenerGenerosDto>>
                {
                    Data = personasList,
                    IsSuccess = true,
                    Message = "Obteniendo todos los generos exitosamente."
                };
            }
            else
            {

                _logger!.LogInformation("{MethodName}: Ningún genero fue encontrado", methodName);

                return new ResponseAPI<IEnumerable<ObtenerGenerosDto>>
                {
                    Data = Enumerable.Empty<ObtenerGenerosDto>(),
                    IsSuccess = true,
                    Message = "Ningún genero fue encontrado."
                };
            }
        }
    }
}
