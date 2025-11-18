using System.ComponentModel.DataAnnotations;

namespace Epik_PersonApp.Application.Dtos.Personas
{
    public class CrearPersonaDto
    {
        [Required(ErrorMessage = "El tipo de identificación es un campo requerido")]
        public Guid TipoIdentificacionId { get; set; }

        [Required(ErrorMessage = "El número de identificación es un campo")]
        public string? Identificacion { get; set; }

        [Required(ErrorMessage = "El nombre(s) es un campo requerido")]
        public string? Nombres { get; set; }

        [Required(ErrorMessage = "Los apellidos es un campo requerido")]
        public string? Apellidos { get; set; }

        [Required(ErrorMessage = "La edad es un campo requerido")]

        [Range(1, 120, ErrorMessage = "El rango de edad debe ser entre 1 y 120 años máximo")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El genero es un campo requerido")]
        public Guid GeneroId { get; set; }



    }
}
