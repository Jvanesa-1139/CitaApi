namespace CitaApi.Entities
{
    public class Cita
    {
        public int Id { get; set; }
        public DateTime Fecha {  get; set; }

        public string Motivo { get; set; }
        public string Estado { get; set; } 
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }

        public Medico? Medico { get; set; }
        public Paciente? Paciente { get; set; }

    }
}
