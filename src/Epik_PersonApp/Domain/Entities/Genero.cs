using Epik_PersonApp.Domain.Common;

namespace Epik_PersonApp.Domain.Entities
{
    public class Genero : BaseEntity
    {
        public string? Descripcion { get; set; }

        public ICollection<Persona>? Personas { get; set; }
    }
}
