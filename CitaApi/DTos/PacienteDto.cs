using CitaApi.Entities;

namespace CitaApi.DTos
{
    public class PacienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string DNI { get; set; }
        public string? Telefono { get; set; }
    }
}
