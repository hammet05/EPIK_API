using Epik_PersonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Epik_PersonApp.Infrastructure.Configuration
{
    public class ConfiguracionGenero : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("Generos");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Descripcion).IsRequired().HasMaxLength(30);

            builder.HasData(

                 new Genero
                 {
                     Id = Guid.Parse("D1867452-8D60-49E1-B6D8-48032577FF1E"),
                     Descripcion = "Femenino",
                     CreatedAt = new DateTime(2025, 01, 01),
                     UpdatedAt = null,
                     IsActive = true,
                 },

                new Genero
                {
                    Id = Guid.Parse("F608F4C5-791B-483D-A467-07C762CF52FD"),
                    Descripcion = "Masculino",
                    CreatedAt = new DateTime(2025, 01, 01),
                    UpdatedAt = null,
                    IsActive = true,
                }
            );
        }
    }
}
