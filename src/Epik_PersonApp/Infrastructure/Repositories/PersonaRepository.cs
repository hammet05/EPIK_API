using Epik_PersonApp.Application.Interfaces.Persistence;
using Epik_PersonApp.Domain.Entities;
using Epik_PersonApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Epik_PersonApp.Infrastructure.Repositories
{
    public class PersonaRepository : Repository<Persona>, IPersonaRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PersonaRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }



        public async Task<int> ContarPersonaPorIdentificacion(string identificacion)
        {
            var count = await _applicationDbContext.Personas.CountAsync(p => p.Identificacion == identificacion);

            return count;
        }

        public async Task<IEnumerable<PersonalFemenino>> ObtenerPersonalFemeninoAsync()
        {
            return await _applicationDbContext.PersonalFemeninoView.ToListAsync();
        }

        public async Task<bool> ActualizarEdadPersona(string numeroIdentificacion, int edad)
        {
            var personaEncontrada = _applicationDbContext!.Personas.FirstOrDefault(p => p.Identificacion == numeroIdentificacion);

            if (personaEncontrada == null)
            {
                return false;
            }

            personaEncontrada.Edad = edad;
            personaEncontrada.SetUpdated();

            await _applicationDbContext.SaveChangesAsync();

            return true;

        }

        public async Task<bool> CambiarEstadoPersona(string numeroIdentificacion, bool estado)
        {
            var personaEncontrada = _applicationDbContext!.Personas.FirstOrDefault(p => p.Identificacion == numeroIdentificacion);

            if (personaEncontrada == null)
            {
                return false;
            }

            personaEncontrada.IsActive = estado;
            personaEncontrada.SetUpdated();

            await _applicationDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EliminarPersona(string numeroIdentificacion)
        {
            var personaEncontrada = _applicationDbContext!.Personas.FirstOrDefault(p => p.Identificacion == numeroIdentificacion);

            if (personaEncontrada == null)
            {
                return false;
            }

            _applicationDbContext.Personas.Remove(personaEncontrada);
            //personaEncontrada.IsActive = estado;
            //personaEncontrada.SetUpdated();

            await _applicationDbContext.SaveChangesAsync();

            return true;
        }
    }
}
