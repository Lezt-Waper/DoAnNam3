using Repository.Model;

namespace Repository.Data
{
    public interface IOrderData
    {
        Task<IEnumerable<Order>> GetAll();
        Task<IEnumerable<Order>> GetByClientId(int clientId);
        Task<IEnumerable<Order>> GetById(int Id);
        Task<int> Save(Order order);
    }
}