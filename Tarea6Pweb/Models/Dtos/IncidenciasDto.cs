﻿namespace Tarea6Pweb.Models.Dtos
{
    public class IncidenciasDto
    {
        public string Pasaporte { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string? WhatsApp { get; set; }

        public DateOnly? FechaNacimiento { get; set; }

        public decimal? Latitud { get; set; }

        public decimal? Longitud { get; set; }

        public string? CodigoAgente { get; set; }
    }
}
