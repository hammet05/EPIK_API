namespace Epik_PersonApp.Application.Dtos.Personas
{
    public class BuscarPersonaPorIdentificacionDto
    {
        public Guid Id { get; set; }
        public string? Identificacion { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }

        public bool IsActive { get; set; }

        public string? TipoIdentificacion { get; set; }

        //public string? GeneroPersona { get; set; }
    }
}
