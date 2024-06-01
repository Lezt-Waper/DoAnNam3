using BlazorApp1.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Repository.Model;

namespace BlazorApp1.Components.Pages;

public partial class Home
{
    [Inject]
    protected IGoodService GoodService { get; set; }
    [Inject]
    protected ICategoryService CategoryService { get; set; }
    [Inject]
    protected ICartService CartService { get; set; }
    public IEnumerable<Good> Goods { get; set; }
    public IEnumerable<Category> Categories { get; set; }

    private int numberOfProduct;

    protected override async Task OnInitializedAsync()
    {
        Goods = await GoodService.GetAll();
        Categories = await CategoryService.GetAll();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await CartService.InitiateStorage();
    }

    protected IOrderedEnumerable<IGrouping<string, Good>> GetGroupGoodByCategoryId()
    {
        return from good in Goods
               group good by good.Category.CategoryId into goodByCategory
               orderby goodByCategory.Key
               select goodByCategory;
    }

    protected string GetCategoryName(IGrouping<string, Good> goodByCategory)
    {
        return goodByCategory.FirstOrDefault(sp => sp.Category.CategoryId == goodByCategory.Key).Category.CategoryName;
    }
}
