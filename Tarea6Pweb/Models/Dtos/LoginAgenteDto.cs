namespace Tarea6Pweb.Models.Dtos
{
    public class LoginAgenteDto
    {
        public string Cedula { get; set; } = null!;

        public string? Correo { get; set; }

        public string ClaveAgente { get; set; } = null!;
    }
}
