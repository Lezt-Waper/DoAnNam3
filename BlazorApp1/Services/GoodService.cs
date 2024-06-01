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

    public async Task<Good> GetById(string id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<Good>($"Good/{id}") ?? default(Good);
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<IEnumerable<Good>> GetByCategoryId(string categoryId)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Good>>($"Good/ByCategory?CategoryId={categoryId}") ?? [];
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<GoodDetail> GetGoodDetail(string id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<GoodDetail>($"GoodDetail/{id}");
        }
        catch (Exception)
        {

            throw;
        }
    }
}
