using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Repository.Model;

namespace BlazorApp1.Services;

public class CartService : ICartService
{
    private ProtectedLocalStorage localStorage;

    public CartService(ProtectedLocalStorage localStorage)
    {
        this.localStorage = localStorage;
    }

    public async Task InitiateStorage()
    {
        var result = await localStorage.GetAsync<List<OrderDetail>>("cartProduct");

        if (!result.Success)
        {
            await localStorage.SetAsync("cartProduct", new List<OrderDetail>());
        }
    }

    public async Task<List<OrderDetail>> GetStorage()
    {
        var result = await localStorage.GetAsync<List<OrderDetail>>("cartProduct");
        return result.Success ? result.Value : new List<OrderDetail>();
    }

    public async Task DeleteStotage()
    {
        await localStorage.SetAsync("cartProduct", new List<OrderDetail>());
    }

    public async Task AddProductToCart(OrderDetail orderDetail)
    {
        List<OrderDetail> orderDetails = await GetStorage();

        if (!orderDetails.Any(o => o.GoodId == orderDetail.GoodId))
        {
            orderDetails.Add(orderDetail);
        }

        await localStorage.SetAsync("cartProduct", orderDetails);
    }

    public async Task SaveStorage(List<OrderDetail> orderDetails)
    {
        await localStorage.SetAsync("cartProduct", orderDetails);
    }
}
