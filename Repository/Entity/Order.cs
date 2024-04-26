using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class Order
    {
        public Client Client { get; set; }
        public List<Good> Good { get; set; }
        public List<int> Quantity { get; set; }
        public bool IsDelivery { get; set; }
    }
}
