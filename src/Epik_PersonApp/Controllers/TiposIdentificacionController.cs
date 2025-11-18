using Epik_PersonApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Epik_PersonApp.Controllers
{
    [Route("api/v1/tiposIdentificacion")]
    [ApiController]
    public class TiposIdentificacionController : ControllerBase
    {
        private readonly ITipoIdentificacionService _tiposIdentificacionService;

        public TiposIdentificacionController(ITipoIdentificacionService tiposIdentificacionService)
        {
            _tiposIdentificacionService = tiposIdentificacionService;
        }

        [HttpGet]
        [Route("obtenerTiposIdentificacion")]
        public async Task<IActionResult> obtenerTiposIdentificacion()
        {
            var response = await _tiposIdentificacionService.ObtenerTodosTiposIdentificacion();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(new { response.Message });

        }
    }
}
