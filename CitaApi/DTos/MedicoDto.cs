using System.ComponentModel.DataAnnotations;

namespace CitaApi.DTos
{
    public class MedicoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
    }
}
