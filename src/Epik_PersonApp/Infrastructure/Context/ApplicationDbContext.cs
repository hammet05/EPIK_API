using Epik_PersonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Epik_PersonApp.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Persona> Personas => Set<Persona>();
        public DbSet<TipoIdentificacion> TipoIdentificaciones => Set<TipoIdentificacion>();

        public DbSet<PersonalFemenino> PersonalFemeninoView => Set<PersonalFemenino>();

        public DbSet<Genero> Generos => Set<Genero>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
