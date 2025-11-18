using Epik_PersonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Epik_PersonApp.Infrastructure.Configuration
{
    public class ConfiguracionPersona : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Personas");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.TipoIdentificacionId).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Identificacion).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Nombres).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Apellidos).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Edad).IsRequired();
            builder.Property(p => p.GeneroId).IsRequired();


            builder.HasIndex(e => e.Identificacion).HasDatabaseName("IX_Persona_NumeroIdentificacion").IsUnique();

            builder.HasOne(p => p.TipoIdentificacion)
                   .WithOne(ti => ti.Persona)
                   .HasForeignKey<Persona>(p => p.TipoIdentificacionId)
                   .IsRequired();

            builder.HasOne(p => p.Genero)
                   .WithMany(g => g.Personas)
                   .HasForeignKey(p => p.GeneroId)
                   .IsRequired();



        }
    }
}
