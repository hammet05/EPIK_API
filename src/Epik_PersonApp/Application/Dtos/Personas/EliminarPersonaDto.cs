using System.ComponentModel.DataAnnotations;

namespace Epik_PersonApp.Application.Dtos.Personas
{
    public class EliminarPersonaDto
    {
        [Required(ErrorMessage = "El número de identificación es un campo requerido")]
        public string? NumeroIdentificacion { get; set; }
    }
}
