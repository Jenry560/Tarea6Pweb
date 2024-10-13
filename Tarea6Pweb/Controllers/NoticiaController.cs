using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tarea6Pweb.Models;
using Tarea6Pweb.Models.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tarea6Pweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public NoticiaController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetNoticia()
        {
            var response = new DataResponse<List<Noticia>>();
            response.Success = false;
            try
            {
                var url = "https://remolacha.net/wp-json/wp/v2/posts?search=migraci%C3%B3n&_fields=title,excerpt";
                var responseNoticia = await _httpClient.GetAsync(url);
                if (!responseNoticia.IsSuccessStatusCode)
                {
                    response.Message = "Ha ocurido un error a la peticion del api de noticia";
                    return BadRequest(response);
                }

                var noticiaJson = await responseNoticia.Content.ReadAsStringAsync();

                var noticias = JsonConvert.DeserializeObject<List<Noticia>>(noticiaJson);

                response.Success = true;
                response.Message = "Noticia retornada con exito";
                response.Result = noticias;

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
