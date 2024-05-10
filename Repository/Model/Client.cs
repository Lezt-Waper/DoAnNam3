using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model;

public class Client
{
    public int ClientId { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Credit { get; set; }
    public string Address { get; set; }
}
