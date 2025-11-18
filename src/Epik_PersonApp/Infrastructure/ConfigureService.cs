using Epik_PersonApp.Application.Interfaces.Persistence;
using Epik_PersonApp.Infrastructure.Context;
using Epik_PersonApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Epik_PersonApp.Infrastructure
{
    public static class ConfigureService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("connection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<ITipoIdentificacionRepository, TipoIdentificacionRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();

            return services;
        }
    }
}
