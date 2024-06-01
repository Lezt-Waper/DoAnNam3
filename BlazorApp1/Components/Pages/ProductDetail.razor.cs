using BlazorApp1.Services;
using Microsoft.AspNetCore.Components;
using Repository.Model;

namespace BlazorApp1.Components.Pages;

public partial class ProductDetail
{
    [Parameter]
    public string ProductId { get; set; }

    [Inject]
    protected IGoodService GoodService {  get; set; }

    public Good Good { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Good = await GoodService.GetById(ProductId);
    }

}
