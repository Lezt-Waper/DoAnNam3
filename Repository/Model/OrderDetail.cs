using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model;

public class OrderDetail
{
    public int OrderDetailId { get; set; }
    public int OrderId { get; set; }
    public string CategoryId { get; set; }
    public string GoodId { get; set; }
    public string GoodName { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public bool IsDelivery { get; set; }
}
