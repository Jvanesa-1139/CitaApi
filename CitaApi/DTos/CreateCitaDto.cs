using CitaApi.Entities;
using CitaApi.Enum;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace CitaApi.DTos
{
    public class CreateCitaDto
    {
        [Required]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage ="Debe ingresar el motivo")]
        public string Motivo { get; set; }
        [Required]
        [EnumDataType(typeof(EnumCita), ErrorMessage = "Estado invalido - no existe")]
        public string Estado { get; set; }
        [Required]
        public int MedicoId { get; set; }
        [Required]
        public int PacienteId { get; set; }

    }
}
