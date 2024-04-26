using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ClientRepository
{
    public interface IClientRepository
    {
        public Task<int> CreateClient(Client client);
        public Task<IEnumerable<Client>> GetClient();
        public Task<Client> GetClient(int id);
    }
}
