using Repository.Model;

namespace Repository.Data
{
    public interface IClientData
    {
        Task<IEnumerable<Client>> Get();
        Task<Client> Get(int id);
        Task<int> Create(Client client);
    }
}