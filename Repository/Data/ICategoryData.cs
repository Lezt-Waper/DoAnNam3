using Repository.Model;

namespace Repository.Data
{
    public interface ICategoryData
    {
        Task<IEnumerable<Category>> Get();
        Task<Category> Get(int Id);
    }
}