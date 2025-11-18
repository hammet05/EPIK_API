using Epik_PersonApp.Application.Interfaces.Persistence;
using Epik_PersonApp.Domain.Entities;
using Epik_PersonApp.Infrastructure.Context;

namespace Epik_PersonApp.Infrastructure.Repositories
{
    public class GeneroRepository : Repository<Genero>, IGeneroRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GeneroRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}
