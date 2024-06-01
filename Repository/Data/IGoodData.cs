using Repository.Model;

namespace Repository.Data
{
    public interface IGoodData
    {
        Task<IEnumerable<Good>> Get();
        Task<Good> Get(string id);
        Task<IEnumerable<Good>> GetByCategoryId(string cId);
    }
}