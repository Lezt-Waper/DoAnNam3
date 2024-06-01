using Repository.Model;

namespace BlazorApp1.Services;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Category>>("Category") ?? [];
        }
        catch (Exception)
        {

            throw;
        }
    }
}
