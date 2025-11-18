using Epik_PersonApp.Application.Dtos.Personas;
using Epik_PersonApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Epik_PersonApp.Controllers
{
    [Route("api/v1/personas")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonasController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpPost]
        [Route("registrar")]

        public async Task<IActionResult> Registrar(CrearPersonaDto crearPersonaDto)
        {
            if (crearPersonaDto == null)
            {
                return BadRequest("La persona no puede tener valores nulos");
            }

            var response = await _personaService.Crear(crearPersonaDto);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet]
        [Route("obtenerTodasPersonas")]
        public async Task<IActionResult> ObtenerTodasPersonas()
        {
            var response = await _personaService.ObtenerTodasPersona();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(new { response.Message });

        }

        [HttpGet("obtenerPersonPorIdentificacion")]
        public async Task<IActionResult> ObtenerPersonPorIdentificacion(string numeroIdentificacion)
        {

            var response = await _personaService!.BuscarPersonaPorIdentificacion(numeroIdentificacion);

            if (!response.IsSuccess)
                return NotFound(response.Message);

            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerPersonalFemenino")]
        public async Task<IActionResult> ObtenerPersonalFemenino()
        {
            var response = await _personaService.ObtenerPersonalFemenino();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(new { response.Message });

        }

        [HttpPatch]
        [Route("actualizarEdad")]
        public async Task<IActionResult> ActualizarEdad(ActualizarEdadDto actualizarEdadDto)
        {
            var response = await _personaService!.ActualizarEdad(actualizarEdadDto.NumeroIdentificacion!, actualizarEdadDto.Edad);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(new { response.Message });
        }

        [HttpPatch("cambiarEstado")]
        public async Task<IActionResult> CambiarEstadoPersona(ActualizarEstadoDto actualizarEstadoDto)
        {
            var response = await _personaService.CambiarEstadoPersona(actualizarEstadoDto.NumeroIdentificacion!, actualizarEstadoDto.Estado);

            if (!response.IsSuccess)
                return NotFound(response.Message);

            return Ok(response);
        }

        [HttpDelete("eliminar")]
        public async Task<IActionResult> EliminarPersona(EliminarPersonaDto eliminarPersonaDto)
        {
            var response = await _personaService.EliminarPersona(eliminarPersonaDto.NumeroIdentificacion!);

            if (!response.IsSuccess)
                return NotFound(response.Message);

            return Ok(response);
        }

    }
}
