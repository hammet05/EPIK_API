namespace Epik_PersonApp.Application.Dtos.Personas
{
    public class PersonalFemeninoDto
    {
        public string? Identificacion { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public int Edad { get; set; }

        public string? TipoIdentificacion { get; set; }
        public string? Genero { get; set; }

        public bool IsActive { get; set; }
    }
}
