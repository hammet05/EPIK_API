using Epik_PersonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Epik_PersonApp.Infrastructure.Configuration
{
    public class ConfiguracionTipoIdentificacion : IEntityTypeConfiguration<TipoIdentificacion>
    {
        public void Configure(EntityTypeBuilder<TipoIdentificacion> builder)
        {
            builder.ToTable("TiposIdentificacion");

            builder.HasKey(ti => ti.Id);

            builder.Property(ti => ti.Codigo).IsRequired().HasMaxLength(3);
            builder.Property(ti => ti.Descripcion).IsRequired().HasMaxLength(100);


            builder.HasData(
                new TipoIdentificacion
                {
                    Id = Guid.Parse("0c0785e7-4863-48f7-ada7-ba819cf91e2d"),
                    Codigo = "CC",
                    Descripcion = "Cédula de Ciudadanía",
                    CreatedAt = new DateTime(2025, 11, 01),
                    UpdatedAt = null,
                    IsActive = true
                },
                new TipoIdentificacion
                {
                    Id = Guid.Parse("1a8d3e2f-4f23-4b0e-9d29-44eae48bbaa1"),
                    Codigo = "PA",
                    Descripcion = "Pasaporte",
                    CreatedAt = new DateTime(2025, 11, 01),
                    UpdatedAt = null,
                    IsActive = true
                },
                new TipoIdentificacion
                {
                    Id = Guid.Parse("2bfe05a9-df9a-4932-8a6a-511d6cccd8e6"),
                    Codigo = "TI",
                    Descripcion = "Tarjeta de Identidad",
                    CreatedAt = new DateTime(2025, 11, 01),
                    UpdatedAt = null,
                    IsActive = true
                },
                new TipoIdentificacion
                {
                    Id = Guid.Parse("3c2f1f66-9a65-44fc-b1ea-34ac2eab2553"),
                    Codigo = "CE",
                    Descripcion = "Cédula de Extranjería",
                    CreatedAt = new DateTime(2025, 11, 01),
                    UpdatedAt = null,
                    IsActive = true
                },
                new TipoIdentificacion
                {
                    Id = Guid.Parse("4e1c1499-8b27-4c65-b9f3-6a1918e842db"),
                    Codigo = "PEP",
                    Descripcion = "Permiso Especial de Permanencia (PEP)",
                    CreatedAt = new DateTime(2025, 11, 01),
                    UpdatedAt = null,
                    IsActive = true
                },
                new TipoIdentificacion
                {
                    Id = Guid.Parse("0c0785e7-4863-48f7-ada7-cfe3b67df097"),
                    Codigo = "RC",
                    Descripcion = "Registro Civil",
                    CreatedAt = new DateTime(2025, 11, 01),
                    UpdatedAt = null,
                    IsActive = true
                }
           );
        }
    }
}
