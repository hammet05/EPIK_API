using Epik_PersonApp.Application.Interfaces.Persistence;
using Epik_PersonApp.Domain.Entities;
using Epik_PersonApp.Infrastructure.Context;

namespace Epik_PersonApp.Infrastructure.Repositories
{
    public class TipoIdentificacionRepository : Repository<TipoIdentificacion>, ITipoIdentificacionRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TipoIdentificacionRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}
