using Repository.Model;

namespace BlazorApp1.Services
{
    public interface IClientService
    {
        Task<int> Create(Client client);
        Task GetKey();
    }
}