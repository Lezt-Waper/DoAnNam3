using Dapper;
using Microsoft.Data.SqlClient;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ClientRepository
{
    public class ClientRepository : IClientRepository
    {
        private readonly Config config;
        public ClientRepository(Config config)
        {
            this.config = config;
        }
        public async Task<int> CreateClient(Client client)
        {
            var connect = new SqlConnection(config.ConnectionString);

            string query = @"INSERT INTO CLIENT (Name, PhoneNumber, Credit, Address)
                             OUTPUT INSERTED.ID
                             VALUES (@Name, @PhoneNumber, @Credit, @Address)";

            var parameter = new DynamicParameters();
            parameter.Add("@Name", client.Name);
            parameter.Add("@PhoneNumber", client.PhoneNumber);
            parameter.Add("@Credit", client.Credit);
            parameter.Add("@Address", client.Address);

            var result = await connect.QueryAsync<int>(query, parameter);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Client>> GetClient()
        {
            var connect = new SqlConnection(config.ConnectionString);

            string query = @"SELECT *
                             FROM CLIENT";

            var result = await connect.QueryAsync<Client>(query);

            return result;
        }

        public async Task<Client> GetClient(int id)
        {
            var connect = new SqlConnection(config.ConnectionString);

            string query = @"SELECT *
                             FROM CLIENT
                             WHERE Id = @Id";

            var result = await connect.QueryAsync<Client>(query, new { Id = id });

            return result.First();
        }
    }
}
