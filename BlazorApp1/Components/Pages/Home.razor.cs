using BlazorApp1.Services;
using Microsoft.AspNetCore.Components;
using Repository.Model;

namespace BlazorApp1.Components.Pages;

public partial class Home
{
    [Inject]
    protected IGoodService GoodService { get; set; }
    public IEnumerable<Good> Goods { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Goods = await GoodService.GetAll();
    }

    protected IOrderedEnumerable<IGrouping<int, Good>> GetGroupGoodByCategoryId()
    {
        return from good in Goods
               group good by good.Category.CategoryId into goodByCategory
               orderby goodByCategory.Key
               select goodByCategory;
    }

    protected string GetCategoryName(IGrouping<int, Good> goodByCategory)
    {
        return goodByCategory.FirstOrDefault(sp => sp.Category.CategoryId == goodByCategory.Key).Category.CategoryName;
    }
}
