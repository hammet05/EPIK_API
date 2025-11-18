namespace Epik_PersonApp.Application.Interfaces.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonaRepository Personas { get; }
        ITipoIdentificacionRepository TiposIdentificacion { get; }

        IGeneroRepository Generos { get; }
        Task SaveChangesAsync();
    }
}
