using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model;

public class Client
{
    public int ClientId { get; set; }
    [StringLength(50)]
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Credit { get; set; }
    [StringLength(50)]
    public string Address { get; set; }
}
