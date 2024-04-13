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
        public Good Good { get; set; }
        public int Quantity { get; set; }
    }
}
