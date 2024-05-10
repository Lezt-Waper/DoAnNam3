using Dapper;
using Microsoft.Data.SqlClient;
using Repository.DbAccess;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data;

public class OrderData : IOrderData
{
    private readonly ISqlDataAccess _db;

    public OrderData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Order>> GetAll()
    {
        Dictionary<int, Order> orders = new Dictionary<int, Order>();

        using var connection = new SqlConnection(_db.GetConnectionString());

        var result = await connection.QueryAsync<Order, OrderDetail, Order>(
            "spOrder_GetAll",
            (order, detail) =>
            {
                Order mappedOrder;

                if (!orders.TryGetValue(order.OrderId, out mappedOrder))
                {
                    mappedOrder = order;
                    mappedOrder.Details = new List<OrderDetail>();
                    orders.Add(mappedOrder.OrderId, mappedOrder);
                }

                mappedOrder.Details.Add(detail);

                return mappedOrder;
            },
            splitOn: "OrderDetailId");

        return result.Distinct().ToList();
    }

    public async Task<IEnumerable<Order>> GetByClientId(int clientId)
    {
        Dictionary<int, Order> orders = new Dictionary<int, Order>();

        using var connection = new SqlConnection(_db.GetConnectionString());

        var result = await connection.QueryAsync<Order, OrderDetail, Order>(
            "spOrder_GetByClientId",
            (order, detail) =>
            {
                Order mappedOrder;

                if (!orders.TryGetValue(order.OrderId, out mappedOrder))
                {
                    mappedOrder = order;
                    mappedOrder.Details = new List<OrderDetail>();
                    orders.Add(mappedOrder.OrderId, mappedOrder);
                }

                mappedOrder.Details.Add(detail);

                return mappedOrder;
            },
            splitOn: "OrderDetailId",
            param: new { ClientId = clientId });

        return result.Distinct().ToList();
    }

    public async Task<IEnumerable<Order>> GetById(int Id)
    {
        Dictionary<int, Order> orders = new Dictionary<int, Order>();

        using var connection = new SqlConnection(_db.GetConnectionString());

        var result = await connection.QueryAsync<Order, OrderDetail, Order>(
            "spOrder_GetById",
            (order, detail) =>
            {
                Order mappedOrder;

                if (!orders.TryGetValue(order.OrderId, out mappedOrder))
                {
                    mappedOrder = order;
                    mappedOrder.Details = new List<OrderDetail>();
                    orders.Add(mappedOrder.OrderId, mappedOrder);
                }

                mappedOrder.Details.Add(detail);

                return mappedOrder;
            },
            splitOn: "OrderDetailId",
            param: new { Id = Id });

        return result.Distinct().ToList();
    }

    public async Task<int> Save(Order order)
    {
        var param = new { ClientId = order.ClientId, Total = order.Total };
        var result = await _db.LoadData<int, dynamic>("spOrder_Insert", param);

        return result.FirstOrDefault();
    }
}
