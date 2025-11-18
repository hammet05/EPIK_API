using Epik_PersonApp.Application.Dtos.TiposIdentificacion;
using Epik_PersonApp.Common;

namespace Epik_PersonApp.Application.Interfaces.Services
{
    public interface ITipoIdentificacionService
    {
        Task<ResponseAPI<IEnumerable<ObtenerTodosTipoIdentificacionDto>>> ObtenerTodosTiposIdentificacion();
    }
}
