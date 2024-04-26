using Microsoft.Data.SqlClient;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.ClientRepository;
using Dapper;

namespace Repository.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Config config;

        public OrderRepository(Config config)
        {
            this.config = config;
        }

        public async Task<int> CreateOrder(Order order)
        {
            var connect = new SqlConnection(config.ConnectionString);

            string queryInsertOrder = @"INSERT INTO ORDER (ClientId, GoodId, Quantity, IsDelivery)
                                        OUTPUT INSERTED.Id
                                        VALUES (@ClientId, @GoodId, @Quantity, @IsDelivery)";

            var listGood = new List<Object>();
            for (int i = 0; i < order.Good.Count; i++)
            {
                listGood.Add(new { ClientId = order.Client.Id, GoodId = order.Good[i].Id, Quantity = order.Quantity[i], IsDelivery = order.IsDelivery});
            }

            var result = await connect.QueryAsync<int>(queryInsertOrder, listGood);

            return result.First();
        }

        public Task<IEnumerable<Order>> GetOrder()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}
