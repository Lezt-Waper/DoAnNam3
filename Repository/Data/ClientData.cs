using Repository.DbAccess;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data;

public class ClientData : IClientData
{
    private readonly ISqlDataAccess _db;

    public ClientData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Client>> Get() =>
        await _db.LoadData<Client, dynamic>("dbo.spClient_GetAll", new { });

    public async Task<Client> Get(int id)
    {
        var result = await _db.LoadData<Client, dynamic>("dbo.spClient_GetById", new { Id = id });
        return result.FirstOrDefault();
    }

    public async Task<int> Create(Client client)
    {
        dynamic parameter = new { 
            Name = client.Name,
            PhoneNumber = client.PhoneNumber,
            Credit = client.Credit,
            Address = client.Address,
        };

        IEnumerable<int> result = await _db.LoadData<int, dynamic>("dbo.spClient_Insert", parameter);

        return result.FirstOrDefault();
        
    }
}
