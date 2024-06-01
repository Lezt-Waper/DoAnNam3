namespace BlazorApp1.Services;

public class NavMenuService : INavMenuService
{
    public event EventHandler? CartChange;

    public void ChangeCart()
    {
        this.CartChange?.Invoke(this, EventArgs.Empty);
    }
}
