using Repository.Model;

namespace BlazorApp1.Services
{
    public interface ICartService
    {
        Task AddProductToCart(OrderDetail orderDetail);
        Task DeleteStotage();
        Task<List<OrderDetail>> GetStorage();
        Task InitiateStorage();
        Task SaveStorage(List<OrderDetail> orderDetails);
    }
}