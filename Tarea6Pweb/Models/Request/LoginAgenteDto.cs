namespace Tarea6Pweb.Models.Request
{
    public class LoginAgenteDto
    {
        public string Cedula { get; set; } = null!;

        public string? Correo { get; set; }

        public string ClaveAgente { get; set; } = null!;
    }
}
