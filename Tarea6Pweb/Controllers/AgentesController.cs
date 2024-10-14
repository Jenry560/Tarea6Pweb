using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Tarea6Pweb.Models;
using Tarea6Pweb.Models.Dtos;
using Tarea6Pweb.Models.Request;
using Tarea6Pweb.Models.Response;

namespace Tarea6Pweb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgentesController : Controller
    {
        private readonly PruebaDbContext _context;
        private readonly IMapper _mapper;

        public AgentesController(PruebaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Registra un nuevo agente en el sistema.
        /// Valida los datos del agente proporcionados y, si son correctos, 
        /// los guarda en la base de datos.
        /// </summary>
        /// <param name="agenteDto">
        /// Objeto que contiene la información del agente a registrar.
        /// </param>
        /// <returns>
        /// Un objeto <see cref="IActionResult"/> que incluye un objeto <see cref="DataResponse{AgenteDto}"/> con el resultado de la operación,
        /// junto con un estado de éxito o error.
        /// </returns>
        /// <response code="201">Retorna la información del agente registrado con éxito.</response>
        /// <response code="400">Solicitud incorrecta si las validaciones fallan o si ocurre un error durante la petición.</response>
        /// <response code="500">Error interno del servidor si ocurre una excepción no controlada.</response>
        [HttpPost("RegistraAgente")]
        public async Task<IActionResult> RegitrarAgente([FromBody] AgenteDto agenteDto)
        {

            var response = new DataResponse<AgenteDto>();
            response.Success = false;
            try
            {

                string mensajeError = validacionesAgente(agenteDto);
                if (!mensajeError.IsNullOrEmpty())
                {
                    response.Message = mensajeError;
                    return BadRequest(response);
                }
                var agente = _mapper.Map<Agente>(agenteDto);

                _context.Agentes.Add(agente);
                await _context.SaveChangesAsync();
                response.Success = true;
                response.Message = "Agente Registrado Correctamente";
                response.Result = _mapper.Map<AgenteDto>(agente);
                return CreatedAtAction(nameof(RegitrarAgente), new { id = agente.Cedula }, response);
            }
            catch (Exception ex)
            {
                {
                    response.Message = ex.Message;
                    return BadRequest(response);
                }
            }
        }

        /// <summary>
        /// Inicia sesión de un agente en el sistema utilizando su correo o cédula y su contraseña.
        /// Verifica las credenciales del agente y retorna la información correspondiente si son válidas.
        /// </summary>
        /// <param name="agenteDto">
        /// Objeto que contiene las credenciales del agente, incluyendo el correo o cédula y la contraseña.
        /// </param>
        /// <returns>
        /// Un objeto <see cref="IActionResult"/> que incluye un objeto <see cref="DataResponse{AgenteDto}"/> con el resultado del inicio de sesión,
        /// junto con un estado de éxito o error.
        /// </returns>
        /// <response code="200">Retorna la información del agente si el inicio de sesión es exitoso.</response>
        /// <response code="400">Solicitud incorrecta si las credenciales son inválidas.</response>
        /// <response code="500">Error interno del servidor si ocurre una excepción no controlada.</response>
        [HttpPost("LoginAgente")]
        public async Task<IActionResult> LoginAgente([FromBody] LoginAgenteDto agenteDto)
        {

            var response = new DataResponse<AgenteDto>();
            response.Success = false;
            try
            {


                var agente = await _context.Agentes.FirstOrDefaultAsync(x => (x.Correo == agenteDto.Correo || x.Cedula == agenteDto.Cedula) && x.ClaveAgente == agenteDto.ClaveAgente);
                if (agente == null)
                {
                    response.Message = "Usuario o contrasena es incorrecta";
                    return BadRequest(response);
                }

                var agenteMapped = _mapper.Map<AgenteDto>(agente);
                response.Success = true;
                response.Message = "Login existoso";
                response.Result = agenteMapped;
                return Ok(response);
            }
            catch (Exception ex)
            {
                {
                    response.Message = ex.Message;
                    return BadRequest(response);
                }
            }

        }
        private string validacionesAgente(AgenteDto agente)
        {
            if (agente.Cedula.Length! != 11)
            {
                return "La cedula debe tener 11 digitos";
            }

            if (_context.Agentes.Any(a => a.Cedula == agente.Cedula))
            {
                return "La cedula ya existe no se puede repetir";
            }

            if (_context.Agentes.Any(a => a.Correo == agente.Correo))
            {
                return "El correo ya existe no se puede repetir";
            }
            return "";
        }
    }
}
