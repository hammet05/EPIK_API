using Epik_PersonApp.Domain.Entities;

namespace Epik_PersonApp.Application.Interfaces.Persistence
{
    public interface IPersonaRepository : IRepository<Persona>
    {
        Task<int> ContarPersonaPorIdentificacion(string identificacion);
        Task<IEnumerable<PersonalFemenino>> ObtenerPersonalFemeninoAsync();

        Task<bool> ActualizarEdadPersona(string numeroIdentificacion, int edad);

        Task<bool> CambiarEstadoPersona(string numeroIdentificacion, bool estado);

        Task<bool> EliminarPersona(string numeroIdentificacion);
    }
}
