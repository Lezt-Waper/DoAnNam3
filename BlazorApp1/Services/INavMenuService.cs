
namespace BlazorApp1.Services
{
    public interface INavMenuService
    {
        event EventHandler? CartChange;

        void ChangeCart();
    }
}