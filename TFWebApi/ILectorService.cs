using TFWebApi.Data.Model;

namespace TFWebApi
{
    public interface ILectorService
    {
        public Task<ICollection<Lector>> GetAll(int pageNumber, int pageSize);
    }
}