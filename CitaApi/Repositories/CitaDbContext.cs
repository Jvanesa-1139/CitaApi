using CitaApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CitaApi.Repositories
{
    public class CitaDbContext: DbContext
    {
    
        public CitaDbContext(DbContextOptions<CitaDbContext> options) : base(options) { }

        public DbSet<Cita> Citas { get; set; }
        public DbSet<Paciente> Pacientes {  get; set; }
        public DbSet<Medico> Medicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
