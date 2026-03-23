using CitaApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace CitaApi.DTos
{
    public class CreatePacienteDto
    {
        [Required]
        [StringLength(100,ErrorMessage ="El campo nombre debe tener 100 caracteres como maximo")]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^\d{8}$", ErrorMessage ="El Dni debe tener 8 digitos")]
        public string DNI { get; set; }
        [RegularExpression(@"^\d{9}$", ErrorMessage = "El Telfono debe tener 9 digitos")]
        public string? Telefono { get; set; }
    }
}
