using Repository.Model;

namespace BlazorApp1.Services;

public class OrderService : IOrderService
{
    private readonly HttpClient _httpClient;

    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Create(Order order)
    {
        try
        {
            var result = await _httpClient.PostAsJsonAsync<Order>("/Order", order);

            if (!result.IsSuccessStatusCode)
            {
                throw new Exception("Can't create order");
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}
