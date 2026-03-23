using CitaApi.DTos;

namespace CitaApi.Repositories
{
    public interface ICitaService
    {
        Task<IEnumerable<CitaDto>> GetAllCitasAsync();
        Task<CitaDto> GetCitaByID(int id);
        Task<bool> CreateCitaAsync(CreateCitaDto Dto);
        Task<bool> UpdateCitaAsync(int id,UpdateCitaDto dto);
        Task<bool> DeleteCitaAsync(int id);
        Task<IEnumerable<CitaDto>> GetCitaByMedicoId(int MedicoId);
    }
}
