using Epik_PersonApp.Domain.Common;

namespace Epik_PersonApp.Domain.Entities
{
    public class Persona : BaseEntity
    {
        public string? Identificacion { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }

        public int Edad { get; set; }
        //public int Genero { get; set; }


        public Guid GeneroId { get; set; }
        public Genero? Genero { get; set; }

        public Guid TipoIdentificacionId { get; set; }
        public TipoIdentificacion? TipoIdentificacion { get; set; }


    }
}
