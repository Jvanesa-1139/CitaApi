using CitaApi.Entities;
using CitaApi.Enum;
using System.ComponentModel.DataAnnotations;

namespace CitaApi.DTos
{
    public class CitaDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }
        public int MedicoId { get; set; }
        public string NombreMedico {  get; set; }
        public string Especialidad { get; set; }
        public int PacienteId { get; set; }
        public string NombrePaciente { get; set; }
    }
}
