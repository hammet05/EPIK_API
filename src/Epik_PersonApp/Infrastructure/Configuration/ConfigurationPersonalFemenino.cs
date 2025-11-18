using Epik_PersonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Epik_PersonApp.Infrastructure.Configuration
{
    public class ConfigurationPersonalFemenino : IEntityTypeConfiguration<PersonalFemenino>
    {
        public void Configure(EntityTypeBuilder<PersonalFemenino> builder)
        {
            builder.HasNoKey();
            builder.ToView("VistaPersonalFemenino");
            builder.Property(v => v.Identificacion).HasColumnName("Identificacion");
            builder.Property(v => v.Nombres).HasColumnName("Nombres");
            builder.Property(v => v.Apellidos).HasColumnName("Apellidos");
            builder.Property(v => v.Edad).HasColumnName("Edad");
            builder.Property(v => v.IsActive).HasColumnName("IsActive");
            builder.Property(v => v.TipoIdentificacion).HasColumnName("TipoIdentificacion");
            builder.Property(v => v.Genero).HasColumnName("Genero");
        }
    }
}
