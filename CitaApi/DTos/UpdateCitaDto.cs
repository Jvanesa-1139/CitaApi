using CitaApi.Enum;
using System.ComponentModel.DataAnnotations;

namespace CitaApi.DTos
{
    public class UpdateCitaDto
    {
       
        [Required]
        [EnumDataType(typeof(EnumCita), ErrorMessage = "Estado invalido - no existe")]
        public string Estado { get; set; }
    }
}
