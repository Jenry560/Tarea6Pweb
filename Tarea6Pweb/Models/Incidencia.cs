
namespace Tarea6Pweb.Models;

public partial class Incidencia
{
    public int IncidenciaId { get; set; }

    public string Pasaporte { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? WhatsApp { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public decimal? Latitud { get; set; }

    public decimal? Longitud { get; set; }

    public int? CodigoAgente { get; set; }

    public virtual Agente? CodigoAgenteNavigation { get; set; }
}
