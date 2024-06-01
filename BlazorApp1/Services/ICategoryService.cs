using Repository.Model;

namespace BlazorApp1.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll();
    }
}