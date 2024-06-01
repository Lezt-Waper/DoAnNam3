using BlazorApp1.Services;
using Microsoft.AspNetCore.Components;
using Repository.Model;

namespace BlazorApp1.Components.Pages;

public partial class CategoryDetail
{
    [Parameter]
    public string CategoryId { get; set; }

    [Inject]
    protected ICategoryService CategoryService { get; set; }
    [Inject]
    protected IGoodService GoodService { get; set; }

    public IEnumerable<Good> Goods { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Goods = await GoodService.GetByCategoryId(CategoryId);
    }

    public string GetCategoryName()
    {
        return Goods.First().Category.CategoryName;
    }

}
