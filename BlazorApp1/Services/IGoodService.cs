using Repository.Model;

namespace BlazorApp1.Services
{
    public interface IGoodService
    {
        Task<IEnumerable<Good>> GetAll();
        Task<IEnumerable<Good>> GetByCategoryId(int categoryId);
        Task<Good> GetById(int id);
    }
}