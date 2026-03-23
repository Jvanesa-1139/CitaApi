using CitaApi.DTos;
using CitaApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CitaApi.Repositories
{
    public class MedicoService : IMedicoService
    {
        private readonly CitaDbContext _DbContext;

        public MedicoService(CitaDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<bool> CreateAsync(CreateMedicoDto dto)
        {
            if(dto == null)
            return false;
            Medico medicoNuevo = new Medico
            {
                Nombre = dto.Nombre,
                Especialidad = dto.Especialidad,
                Email = dto.Email
            };

            _DbContext.Medicos.Add(medicoNuevo);
            await _DbContext.SaveChangesAsync();
            return true;


        }

        public async Task<string> DeleteAsync(int id)
        {
            var Existe = await _DbContext.Medicos
                        .Include(m=>m.Citas)
                        . FirstOrDefaultAsync(C=> C.Id==id);
            if (Existe == null)
                return "NotFound";

            if(Existe.Citas.Any())
                return "Tiene Citas";

            _DbContext.Remove(Existe);
            await _DbContext.SaveChangesAsync();
            return "Success";
        }

        public async Task<IEnumerable<MedicoDto>> GetAllAsync()
        {
            var medicos = await _DbContext.Medicos
                            .Select(m => new MedicoDto
                            {
                                Id = m.Id,
                                Nombre=m.Nombre,
                                Especialidad=m.Especialidad
                            }).ToListAsync();
            return medicos;
        }

        public async Task<MedicoDto> GetByIdAsync(int id)
        {
            var existe = await _DbContext.Medicos
                        .Select(m=> new MedicoDto
                        {
                            Id = m.Id,
                            Nombre=m.Nombre,
                            Especialidad = m.Especialidad
                        }).FirstOrDefaultAsync(m=> m.Id==id);
            if (existe == null)
                return null;
            return existe;
             
            
        }

        public async Task<bool> UpdateAsync(int Id,UpdateMedicoDto UpDto)
        {
            var existe = await _DbContext.Medicos.FirstOrDefaultAsync(m => m.Id==Id);

            if (existe == null)
                return false;

            existe.Nombre= UpDto.Nombre;
            existe.Especialidad= UpDto.Especialidad;
            existe.Email = UpDto.Email;

            await _DbContext.SaveChangesAsync();

            return true;
        }
    }
}
