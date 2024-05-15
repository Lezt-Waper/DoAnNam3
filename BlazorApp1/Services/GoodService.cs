using Repository.Model;

namespace BlazorApp1.Services;

public class GoodService : IGoodService
{
    private readonly HttpClient _httpClient;
    public GoodService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Good>> GetAll()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Good>>("Good/All") ?? [];
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<Good> GetById(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<Good>($"Good/GetById/{id}") ?? default(Good);
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<IEnumerable<Good>> GetByCategoryId(int categoryId)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Good>>($"Good/ByCategoryId?categoryId={categoryId}") ?? [];
        }
        catch (Exception)
        {

            throw;
        }
    }
}
