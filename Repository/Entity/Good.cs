using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class Good
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

    }
}
