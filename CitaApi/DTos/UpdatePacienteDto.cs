using System.ComponentModel.DataAnnotations;

namespace CitaApi.DTos
{
    public class UpdatePacienteDto
    {
        [Required]
        [StringLength(100,ErrorMessage ="El campo nombre no debe tener mas de 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^\d{8}",ErrorMessage ="EL dni debe tener 8 digistos")]
        public string DNI { get; set; }
        [RegularExpression(@"^\d{9}", ErrorMessage ="El telefono debe tener 9 digitos")]
        public string? Telefono { get; set; }

    }
}
