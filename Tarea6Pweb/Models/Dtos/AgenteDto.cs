namespace Tarea6Pweb.Models.Dtos
{
    public class AgenteDto
    {
        public int AgenteId { get; set; }
        public string Cedula { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string? Telefono { get; set; }

        public string? Correo { get; set; }

        public string ClaveAgente { get; set; } = null!;
    }
}
