namespace CitaApi.Entities
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Especialidad { get; set; } = string.Empty;
        public string? Email { get; set; } 

        public List<Cita> Citas {  get; set; }=new List<Cita>();
    }
}
