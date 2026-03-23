using CitaApi.DTos;
using CitaApi.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CitaApi.Repositories
{
    public class PacienteService : IPacienteService
    {
        private readonly CitaDbContext _citaDb;
        public PacienteService(CitaDbContext citaDb)
        {
            _citaDb = citaDb;
        }
        public async Task<bool> CreatePacienteAsync(CreatePacienteDto paciente)
        {
            if (paciente == null)
                return false;
            Paciente PacienteNuevo = new Paciente
            {
                Nombre = paciente.Nombre,
                DNI = paciente.DNI,
                Telefono = paciente.Telefono,
            };

            _citaDb.Pacientes.Add(PacienteNuevo);
            await _citaDb.SaveChangesAsync();
            return true;
  
        }

        public async Task<string> DeletePacienteAsync(int id)
        {
            var existe = await _citaDb.Pacientes
                .Include(p=>p.Citas)
                .FirstOrDefaultAsync(p=>p.Id == id);

            if (existe == null)
                return "Not Found";
            if (existe.Citas.Any())
                return "Tiene Citas";
            _citaDb.Pacientes.Remove(existe);
            await _citaDb.SaveChangesAsync() ;

            return "Succes";

        }

        public async Task<IEnumerable<PacienteDto>> GetAll()
        {
            var pacientes = await _citaDb.Pacientes
                            .Select(p => new PacienteDto
                            {
                                Id = p.Id,
                                Nombre = p.Nombre,
                                DNI = p.DNI,
                                Telefono = p.Telefono
                            }).ToListAsync();
            return pacientes;
        }

        public async Task<PacienteDto> getPacienteById(int id)
        {
            var paciente = await _citaDb.Pacientes
                            .Select(p=> new PacienteDto
                            {
                                Id = p.Id,
                                Nombre = p.Nombre,
                                DNI = p.DNI,
                                Telefono = p.Telefono
                            }).FirstOrDefaultAsync(p=>p.Id== id);           
                if (paciente != null)
                return paciente;
            return null;
        }

        public async Task<bool> UpdatePacienteAsync(int id, UpdatePacienteDto UpPaciente)
        {
              var existe = await _citaDb.Pacientes.FirstOrDefaultAsync(p=>p.Id== id);

            if(existe ==null)
                return false;
        
            existe.Nombre = UpPaciente.Nombre;
            existe.DNI = UpPaciente.DNI;
            existe.Telefono= UpPaciente.Telefono;

            await _citaDb.SaveChangesAsync();
            return true;
        }
    }
}
