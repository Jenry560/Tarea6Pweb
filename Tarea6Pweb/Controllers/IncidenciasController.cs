
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea6Pweb.Models;
using Tarea6Pweb.Models.Dtos;
using Tarea6Pweb.Models.Response;

namespace Tarea6Pweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidenciasController : ControllerBase
    {
        private readonly PruebaDbContext _context;
        private readonly IMapper _mapper;

        public IncidenciasController(PruebaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Incidencia>> PostIncidencia(IncidenciasDto incidenciaDto)
        {
            var response = new DataResponse<int>();
            response.Success = false;
           
            try
            {
                var incidencia = _mapper.Map<Incidencia>(incidenciaDto);
                _context.Incidencias.Add(incidencia);
                await _context.SaveChangesAsync();
                response.Success = true;
                response.Message = "Incidencia registrada Exitosamente";
                response.Result = incidencia.IncidenciaId;
                return CreatedAtAction(nameof(PostIncidencia), new { id = incidenciaDto.IncidenciaId }, response);
            }
            catch (DbUpdateException)
            {
                if (!IncidenciaExistsCodigoAgente(incidenciaDto.CodigoAgente))
                {
                    response.Message = "No hay un agente con ese codigo";
                    return Conflict(response);
                }
                else
                {
                    response.Message = "Ha ocurrido un error";
                    return BadRequest(response);
                }
            }
        
        }



        private bool IncidenciaExistsCodigoAgente(int id)
        {
            return _context.Agentes.Any(e => e.AgenteId == id);
        }
    }
}
