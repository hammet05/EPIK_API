using Epik_PersonApp.Domain.Common;

namespace Epik_PersonApp.Domain.Entities
{
    public class TipoIdentificacion : BaseEntity
    {
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }

        public Persona? Persona { get; set; }

    }
}
