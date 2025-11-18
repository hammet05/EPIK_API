namespace Epik_PersonApp.Application.Dtos.Personas
{
    public class ObtenerTodasPersonasDto
    {
        public Guid Id { get; set; }
        public string? Identificacion { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }

        public int Edad { get; set; }


        public bool IsActive { get; set; }

        public string? TipoIdentificacion { get; set; }

        public string? GeneroPersona { get; set; }


    }
}
