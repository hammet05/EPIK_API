using Epik_PersonApp.Application.Dtos.Generos;
using Epik_PersonApp.Common;

namespace Epik_PersonApp.Application.Interfaces.Services
{
    public interface IGeneroService
    {
        Task<ResponseAPI<IEnumerable<ObtenerGenerosDto>>> ObtenerGeneros();
    }
}
