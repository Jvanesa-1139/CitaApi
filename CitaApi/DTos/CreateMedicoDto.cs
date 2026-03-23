using System.ComponentModel.DataAnnotations;

namespace CitaApi.DTos
{
    public class CreateMedicoDto
    {
        [Required]
        [StringLength(100, ErrorMessage ="El nombre no puede ser mayor a 100 caracteres")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(100, ErrorMessage ="EL campo Especialidad no debe ser mayor que 100 carctaeres")]
        public string Especialidad { get; set; }
        [EmailAddress]
        public string? Email { get; set; }


    }
}
