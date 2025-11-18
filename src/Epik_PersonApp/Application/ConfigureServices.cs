using Epik_PersonApp.Application.Interfaces.Services;
using Epik_PersonApp.Application.UsesCases.Generos;
using Epik_PersonApp.Application.UsesCases.Personas;
using Epik_PersonApp.Application.UsesCases.TiposIdentificacion;
using System.Reflection;

namespace Epik_PersonApp.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IPersonaService, PersonaService>();
            services.AddScoped<ITipoIdentificacionService, TiposIdentificacionService>();
            services.AddScoped<IGeneroService, GenerosService>();

            return services;
        }
    }
}
