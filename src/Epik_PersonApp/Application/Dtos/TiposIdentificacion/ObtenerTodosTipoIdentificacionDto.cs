namespace Epik_PersonApp.Application.Dtos.TiposIdentificacion
{
    public class ObtenerTodosTipoIdentificacionDto
    {
        public Guid Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public bool IsActive { get; set; }
    }
}
