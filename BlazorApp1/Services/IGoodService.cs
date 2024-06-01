using Repository.Model;

namespace BlazorApp1.Services
{
    public interface IGoodService
    {
        Task<IEnumerable<Good>> GetAll();
        Task<IEnumerable<Good>> GetByCategoryId(string categoryId);
        Task<Good> GetById(string id);
        Task<GoodDetail> GetGoodDetail(string id);
    }
}