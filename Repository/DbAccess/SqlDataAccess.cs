using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DbAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration configuration)
    {
        _config = configuration;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionID = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionID));

        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string storedProcedure, T parameters, string conncetionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(conncetionId));

        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public string GetConnectionString(string connectionID = "Default")
    {
        return _config.GetConnectionString(connectionID);
    }
}
