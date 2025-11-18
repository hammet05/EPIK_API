using Epik_PersonApp.Application.Interfaces.Persistence;
using Epik_PersonApp.Infrastructure.Context;

namespace Epik_PersonApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            Personas = new PersonaRepository(applicationDbContext);
            TiposIdentificacion = new TipoIdentificacionRepository(applicationDbContext);
            Generos = new GeneroRepository(applicationDbContext);
        }

        public IPersonaRepository Personas { get; }

        public ITipoIdentificacionRepository TiposIdentificacion { get; }

        public IGeneroRepository Generos { get; }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
