namespace Epik_PersonApp.Application.Dtos.Generos
{
    public class ObtenerGenerosDto
    {
        public Guid Id { get; set; }
        public string? Descripcion { get; set; }

        public bool IsActive { get; set; }
    }
}
