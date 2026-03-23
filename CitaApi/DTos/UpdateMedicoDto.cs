using System.ComponentModel.DataAnnotations;

namespace CitaApi.DTos
{
    public class UpdateMedicoDto
    {
        [Required]
        [StringLength(100,ErrorMessage ="El campo nombre no puede ser mayor a 100 caracteres")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(100,ErrorMessage ="El campo especilidad no puede ser mayor a 100 caracteres")]
        public string Especialidad { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
    }
}
