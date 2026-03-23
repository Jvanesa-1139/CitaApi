using CitaApi.DTos;
using CitaApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CitaApi.Repositories
{
    public class CitaService : ICitaService
    {
        private readonly CitaDbContext _context;    
        public CitaService(CitaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCitaAsync(CreateCitaDto Dto)
        {
            if (Dto == null)
                return false;
            if(Dto.Fecha < DateTime.Now)
                return false;
            Cita CitaNueva = new Cita
            {
                Fecha = Dto.Fecha,
                Motivo = Dto.Motivo,
                Estado = Dto.Estado,
                MedicoId = Dto.MedicoId,
                PacienteId = Dto.PacienteId,

            };

            _context.Citas.Add(CitaNueva);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteCitaAsync(int id)
        {
            var existe = await _context.Citas.FirstOrDefaultAsync(c => c.Id == id);
            if (existe == null)
                return false;
            _context.Citas.Remove(existe);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CitaDto>> GetAllCitasAsync()
        {
            var Citas = await _context.Citas
                        .Include(c => c.Medico)
                        .Include(c => c.Paciente)
                        .Select(c => new CitaDto
                        {
                            Id = c.Id,
                            Fecha = c.Fecha,
                            Motivo = c.Motivo,
                            Estado = c.Estado,
                            Especialidad = c.Medico.Especialidad,
                            MedicoId = c.MedicoId,
                            NombreMedico = c.Medico.Nombre,
                            PacienteId = c.PacienteId,
                            NombrePaciente = c.Paciente.Nombre

                        }).ToListAsync();
           return Citas;
        }

        public async Task<CitaDto> GetCitaByID(int id)
        {
            var existe = await _context.Citas
                        .Include(c => c.Medico)
                        .Include(c=>c.Paciente)
                        .Select(c=> new CitaDto
                        {
                            Id=c.Id,
                            Fecha = c.Fecha,
                            Motivo=c.Motivo,
                            Estado = c.Estado,
                            Especialidad= c.Medico.Especialidad,
                            MedicoId = c.MedicoId,
                            NombreMedico= c.Medico.Nombre,
                            PacienteId = c.PacienteId,
                            NombrePaciente = c.Paciente.Nombre
                        }).FirstOrDefaultAsync(c=> c.Id == id);
            if (existe == null)
                return null;
            return existe;
        }

        public async Task<IEnumerable<CitaDto>> GetCitaByMedicoId(int MedicoId)
        {
            var citas = await _context.Citas
                       .Include(c => c.Medico)
                       .Include(c => c.Paciente)
                       .Select(c => new CitaDto
                       {
                           Id = c.Id,
                           Fecha = c.Fecha,
                           Motivo = c.Motivo,
                           Estado = c.Estado,
                           Especialidad = c.Medico.Especialidad,
                           MedicoId = c.MedicoId,
                           NombreMedico = c.Medico.Nombre,
                           PacienteId = c.PacienteId,
                           NombrePaciente = c.Paciente.Nombre
                       }).Where(c => c.MedicoId == MedicoId).ToListAsync();
            if (citas == null)
                return null;

            return citas;
        }

        public async Task<bool> UpdateCitaAsync(int id, UpdateCitaDto dto)
        {
            var existe = await _context.Citas.FirstOrDefaultAsync(c => c.Id == id);
            if (existe == null)
                return false;

                existe.Estado = dto.Estado;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
