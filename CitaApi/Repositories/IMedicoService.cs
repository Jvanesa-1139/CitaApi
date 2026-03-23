using CitaApi.DTos;

namespace CitaApi.Repositories
{
    public interface IMedicoService
    {
        Task<IEnumerable<MedicoDto>> GetAllAsync();
        Task<MedicoDto> GetByIdAsync(int id);
        Task<bool> CreateAsync (CreateMedicoDto dto);
        Task<bool> UpdateAsync (int Id,UpdateMedicoDto UpDto);
        Task<string> DeleteAsync (int id);

    }
}
