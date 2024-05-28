using TFWebApi.Data.Model;
using TFWebApi.Data.Model.DTO;

namespace TFWebApi.Interfaces
{
    public interface IDatabaseService
    {
        Task<List<Lector>> GetAllAsync();
        Task<Lector> GetById(int id);
        Task<bool> CreateAsync(Lector lector);
        Task<bool> UpdateAsync(Lector lector);
        Task<bool> DeleteAsync(int id);
    }
}
