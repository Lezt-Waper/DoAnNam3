using BlazorApp1.Services;
using Microsoft.AspNetCore.Components;
using Repository.Model;
using System.ComponentModel;

namespace BlazorApp1.Components.Pages;

public partial class Payment
{
    [Inject]
    protected ICartService CartService { get; set; }
    [Inject]
    protected IClientService ClientService { get; set; }
    [Inject]
    protected IOrderService OrderService { get; set; }
    
    private List<OrderDetail> cartProduct;
    
    private Client Client { get; set; }
    private Toast toast;

    protected override void OnInitialized()
    {
        Client = new Client();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            cartProduct = await CartService.GetStorage();
            StateHasChanged();
        }
    }

    private async Task HandleSubmition()
    {
        var result = await ClientService.Create(Client);

        Order order = new Order();
        order.ClientId = result;
        order.Total = CalculateTotal();
        order.Details = cartProduct;

        await OrderService.Create(order);

        await CartService.DeleteStotage();
        cartProduct = new List<OrderDetail>();
        Client = new Client();

        toast.ShowSuccess("Bạn đã thanh toán thành công");
    }

    private int CalculateTotal()
    {
        int result = 0;
        foreach (var item in cartProduct)
        {
            result += (item.Price * item.Quantity);
        }

        return result;
    }
}
