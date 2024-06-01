using BlazorApp1.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Components.Layout;

partial class NavMenu : IDisposable
{
    [Inject]
    protected ICartService CartService { get; set; }
    [Inject]
    protected INavMenuService NavMenuService { get; set; }
    

    public int NumberOfProduct {  get; set; } = 0;

    protected override void OnInitialized()
    {
        NavMenuService.CartChange += this.Refresh;
    }

    protected override async Task OnAfterRenderAsync(bool firstrender)
    {
        if (firstrender)
        {
            var cartProduct = await CartService.GetStorage();
            NumberOfProduct = cartProduct.Count;
            StateHasChanged();
        }
    }

    public void Refresh(object? sender, EventArgs e)
    {
        InvokeAsync(StateHasChanged);
    }

    public void Dispose()
    {
        NavMenuService.CartChange -= this.Refresh;
    }
}
