using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using Tarea6Pweb.Models;
using Tarea6Pweb.Models.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tarea6Pweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimaController : ControllerBase
    {

        private readonly HttpClient _httpClient;
        /// <summary>
        /// Todo lo del clima.
        /// </summary>
        public ClimaController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        /// <summary>
        /// Obtiene información del clima de los proximo 7 dias basado en la latitud y longitud.
        /// </summary>
        /// <param name="latitudLogitud">Latitud y longitud separadas por una coma (ejemplo: '34.0522,-118.2437').</param>
        /// <returns>Información del clima.</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string latitudLogitud)
        {
            var response = new DataResponse<Clima>();
            response.Success = false;

            try
            {
                var url = $"https://api.weatherapi.com/v1/forecast.json?q={latitudLogitud}&days=7&lang=es&key=23cb77701fee4dff9f4185848241310";
                var climaRes = await _httpClient.GetAsync(url);
                if (!climaRes.IsSuccessStatusCode)
                {
                    response.Message = "La peticion a la noticia no se pudo completar";
                    return BadRequest(response);
                }


                var climaJson = await climaRes.Content.ReadAsStringAsync();
                response.Result = JsonConvert.DeserializeObject<Clima>(climaJson);
                response.Message = "Peticion exitosa";
                response.Success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
               response.Message = ex.Message;
                return BadRequest(response);
            
            }
        }

    }
}
