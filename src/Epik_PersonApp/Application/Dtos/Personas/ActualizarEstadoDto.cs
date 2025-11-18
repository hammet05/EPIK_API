using System.ComponentModel.DataAnnotations;

namespace Epik_PersonApp.Application.Dtos.Personas
{
    public class ActualizarEstadoDto
    {

        [Required(ErrorMessage = "El número de identificación es un campo requerido")]
        public string? NumeroIdentificacion { get; set; }

        [Required(ErrorMessage = "El estado es un campo requerido")]

        public bool Estado { get; set; }
    }
}
