using System.ComponentModel.DataAnnotations;

namespace Epik_PersonApp.Application.Dtos.Personas
{
    public class ActualizarEdadDto
    {
        [Required(ErrorMessage = "El número de identificación es un campo requerido")]
        public string? NumeroIdentificacion { get; set; }

        [Required(ErrorMessage = "La edad es un campo requerido")]

        [Range(1, 120, ErrorMessage = "El rango de edad debe ser entre 1 y 120 años máximo")]

        public int Edad { get; set; }
    }
}
