
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea6Pweb.Models;
using Tarea6Pweb.Models.Dtos;

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
            var response = new DataResponse<IncidenciasDto>();
            response.Success = false;
           
            try
            {
                var incidencia = _mapper.Map<Incidencia>(incidenciaDto);
                _context.Incidencias.Add(incidencia);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IncidenciaExists(incidenciaDto.Pasaporte))
                {
                    response.Message = "Ya existe incidencia con ese pasaprote";
                    return Conflict(response);
                }
                else
                {
                    response.Message = "Ha ocurrido un error";
                    return BadRequest(response);
                }
            }
            response.Success = true;
            response.Message = "Incidencia registrada Exitosamente";
            response.Result = incidenciaDto;
            return CreatedAtAction("GetIncidencia", new { id = incidenciaDto.Pasaporte }, response);
        }

        // DELETE: api/Incidencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncidencia(string id)
        {
            var incidencia = await _context.Incidencias.FindAsync(id);
            if (incidencia == null)
            {
                return NotFound();
            }

            _context.Incidencias.Remove(incidencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncidenciaExists(string id)
        {
            return _context.Incidencias.Any(e => e.Pasaporte == id);
        }
    }
}
