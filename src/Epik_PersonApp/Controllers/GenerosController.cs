using Epik_PersonApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Epik_PersonApp.Controllers
{
    [Route("api/v1/generos")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IGeneroService _generoService;

        public GenerosController(IGeneroService generoService)
        {
            _generoService = generoService;
        }


        [HttpGet]
        [Route("obtenerGeneros")]
        public async Task<IActionResult> ObtenerTodasPersonas()
        {
            var response = await _generoService.ObtenerGeneros();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(new { response.Message });

        }
    }
}
