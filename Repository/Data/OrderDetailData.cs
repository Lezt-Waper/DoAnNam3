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

public class OrderDetailData : IOrderDetailData
{
    private readonly ISqlDataAccess _db;
    public OrderDetailData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<OrderDetail>> LoadAll()
    {
        return await _db.LoadData<OrderDetail, dynamic>("dbo.spOrderDetail_GetAll", new { });
    }

    public async Task<IEnumerable<OrderDetail>> LoadByOrderId(int orderId)
    {
        return await _db.LoadData<OrderDetail, dynamic>("dbo.spOrderDetail_GetByOrderId", new { OrderId = orderId });
    }

    public async Task<IEnumerable<OrderDetail>> LoadByGoodId(string goodId)
    {
        return await _db.LoadData<OrderDetail, dynamic>("dbo.spOrderDetail_GetByGoodId", new { GoodId = goodId });
    }

    public async Task Save(IEnumerable<OrderDetail> orderDetails, int orderId)
    {
        dynamic param;

        foreach (var item in orderDetails)
        {
            param = new
            {
                OrderId = orderId,
                GoodId = item.GoodId,
                Quantity = item.Quantity,
            };

            await _db.SaveData<dynamic>("dbo.spOrderDetail_Insert", param);
        }
    }

}
