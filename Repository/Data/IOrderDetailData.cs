﻿using Repository.Model;

namespace Repository.Data
{
    public interface IOrderDetailData
    {
        Task<IEnumerable<OrderDetail>> LoadAll();
        Task<IEnumerable<OrderDetail>> LoadByGoodId(int goodId);
        Task<IEnumerable<OrderDetail>> LoadByOrderId(int orderId);
        Task Save(IEnumerable<OrderDetail> orderDetails, int orderId);
    }
}