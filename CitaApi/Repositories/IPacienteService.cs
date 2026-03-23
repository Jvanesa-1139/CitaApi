using CitaApi.DTos;

namespace CitaApi.Repositories
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteDto>> GetAll();
        Task<PacienteDto> getPacienteById(int id);
        Task<bool> CreatePacienteAsync(CreatePacienteDto paciente);
        Task<bool> UpdatePacienteAsync(int id, UpdatePacienteDto UpPaciente);
        Task<string> DeletePacienteAsync(int id);
    }
}
