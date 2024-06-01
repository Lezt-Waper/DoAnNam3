using BlazorApp1.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Repository.Model;

namespace BlazorApp1.Components.Pages;

public partial class Cart
{
    [Inject]
    protected ICartService CartService { get; set; } 

    private List<OrderDetail> cartProduct;

    protected override async Task OnAfterRenderAsync(bool firstrender)
    {
        if (firstrender)
        {
            cartProduct = await CartService.GetStorage();
            StateHasChanged();
        }
    }

    public async Task DeleteCart()
    {
        await CartService.DeleteStotage();
        cartProduct.Clear();
        StateHasChanged();
    }
}
