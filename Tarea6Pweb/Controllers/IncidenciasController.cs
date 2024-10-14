
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


        /// <summary>
        /// Crea una nueva incidencia en el sistema.
        /// Realiza el mapeo del DTO de incidencia al modelo de base de datos y lo guarda.
        /// </summary>
        /// <param name="incidenciaDto">
        /// Objeto DTO que contiene los datos de la incidencia a registrar.
        /// </param>
        /// <returns>
        /// Un resultado de acción que incluye el ID de la nueva incidencia creada,
        /// junto con una respuesta que indica el éxito o fallo de la operación.
        /// </returns>
        /// <response code="201">Devuelve el ID de la incidencia creada exitosamente.</response>
        /// <response code="409">Conflicto, cuando no existe un agente con el código proporcionado.</response>
        /// <response code="400">Solicitud incorrecta, cuando ocurre un error al guardar la incidencia.</response>
        /// <response code="500">Error interno del servidor, si ocurre un error inesperado.</response>
        [HttpPost]
        public async Task<IActionResult> PostIncidencia(IncidenciasDto incidenciaDto)
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


        //Si existe un agente con el código proporcionado
        private bool IncidenciaExistsCodigoAgente(int id)
        {
            return _context.Agentes.Any(e => e.AgenteId == id);
        }
    }
}
