using Repository.Model;

namespace BlazorApp1.Services
{
    public interface IOrderService
    {
        Task Create(Order order);
    }
}