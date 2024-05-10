using Repository.Model;

namespace Repository.Data
{
    public interface IGoodData
    {
        Task<IEnumerable<Good>> Get();
        Task<Good> Get(int id);
        Task<IEnumerable<Good>> GetByCategoryId(int cId);
    }
}