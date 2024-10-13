using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Tarea6Pweb.Models;
using Tarea6Pweb.Models.Dtos;

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
                response.Result = agenteDto;
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
        [HttpPost("LoginAgente")]
        public async Task<IActionResult> LoginAgente([FromBody] LoginAgenteDto agenteDto)
        {

            var response = new DataResponse<AgenteDto>();
            response.Success = false;
            try
            {
                
              
                var agente = await _context.Agentes.FirstOrDefaultAsync(x=> ( x.Correo == agenteDto.Correo || x.Cedula == agenteDto.Cedula ) && x.ClaveAgente == agenteDto.ClaveAgente);
                if(agente  == null)
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
