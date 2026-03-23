namespace CitaApi.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }=string.Empty;
        public string DNI { get; set; }
        public string? Telefono { get; set; }
        public List<Cita> Citas { get; set; }=new List<Cita>();
    }
}
