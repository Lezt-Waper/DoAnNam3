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
    public int GoodId { get; set; }
    public string GoodName { get; set; }
    public int Quantity { get; set; }
    public bool IsDelivery { get; set; }
}
