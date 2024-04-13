using Dapper;
using Microsoft.Data.SqlClient;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GoodRepository
{
    public class GoodRepository : IGoodRepository
    {
        private readonly Config config;

        public GoodRepository(Config config)
        {
            this.config = config;
        }

        public async Task<IEnumerable<Good>> Get()
        {
            var connect = new SqlConnection(config.ConnectionString);

            string query = @"SELECT G.Id, G.Name, G.Quantity, C.Id AS CategoryId, C.Name
                             FROM Good G INNER JOIN Category C
                                ON G.CategoryId = C.Id";

            var result = await connect.QueryAsync<Good, Category, Good>(query, (good, category) => {
                good.Category = category;
                return good;
            },
            splitOn: "CategoryId");

            return result;
        }

        public async Task<Good> Get(int id)
        {
            var numberGood = await GetNumberOfGood();

            if (id > numberGood)
            {
                throw new IndexOutOfRangeException();
            }

            var connect = new SqlConnection(config.ConnectionString);

            string query = @"SELECT G.Id, G.Name, G.Quantity, C.Id AS CategoryId, C.Name
                             FROM Good G INNER JOIN Category C
                                ON G.CategoryId = C.Id
                             WHERE G.Id = @Id";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id);

            var result = await connect.QueryAsync<Good, Category, Good>(query, (good, category) => {
                good.Category = category;
                return good;
            },
            parameters,
            splitOn: "CategoryId");

            return result.FirstOrDefault();
        }

        public async Task<int> GetNumberOfGood()
        {
            var conncet = new SqlConnection(config.ConnectionString);

            var query = @"SELECT COUNT(*)
                          FROM Good";

            var result = await conncet.QueryAsync<int>(query);

            return result.FirstOrDefault();
        }
    }
}
