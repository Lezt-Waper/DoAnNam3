using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderRepository
{
    public interface IOrderRepository
    {
        public Task<int> CreateOrder(Order order);
        public Task<IEnumerable<Order>> GetOrder();
        public Task<Order> GetOrder(int id);
    }
}
