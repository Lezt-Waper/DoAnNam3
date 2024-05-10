using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model;

public class Order
{
    public int OrderId { get; set; }
    public int ClientId { get; set; }
    public int Total { get; set; }
    public List<OrderDetail> Details { get; set; }
}
