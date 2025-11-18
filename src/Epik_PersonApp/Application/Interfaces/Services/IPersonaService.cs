using Epik_PersonApp.Application.Dtos.Personas;
using Epik_PersonApp.Common;

namespace Epik_PersonApp.Application.Interfaces.Services
{
    public interface IPersonaService
    {
        Task<ResponseAPI<bool>> Crear(CrearPersonaDto crearPersonaDto);

        Task<ResponseAPI<IEnumerable<ObtenerTodasPersonasDto>>> ObtenerTodasPersona();
        Task<ResponseAPI<BuscarPersonaPorIdentificacionDto>> BuscarPersonaPorIdentificacion(string numeroIdentificacion);

        Task<ResponseAPI<IEnumerable<PersonalFemeninoDto>>> ObtenerPersonalFemenino();

        Task<ResponseAPI<bool>> ActualizarEdad(string numeroIdentificacion, int edad);

        Task<ResponseAPI<bool>> CambiarEstadoPersona(string numeroIdentificacion, bool estado);

        Task<ResponseAPI<bool>> EliminarPersona(string numeroIdentificacion);

        //Task<Response<IEnumerable<GetUniqueEmployeeDto>>> GetEmployeeByName(string name);


        //Task<Response<GetUniqueEmployeeDto>> GetEmployeeById(Guid id);





        //Task<Response<bool>> ActivateEmployeeAsync(Guid id);
    }
}
