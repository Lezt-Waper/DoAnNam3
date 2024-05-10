using Dapper;
using Microsoft.Data.SqlClient;
using Repository.DbAccess;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data;

public class GoodData : IGoodData
{
    private readonly ISqlDataAccess _db;

    public GoodData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Good>> Get()
    {
        using var connect = new SqlConnection(_db.GetConnectionString());

        var goods = await connect.QueryAsync<Good, Category, Good>(
            "dbo.spGood_GetAll",
            (good, category) =>
            {
                good.Category = category;
                return good;
            },
            splitOn: "CategoryId");

        return goods.Distinct().ToList();
    }
    public async Task<Good> Get(int id)
    {
        using var connect = new SqlConnection(_db.GetConnectionString());

        var goods = await connect.QueryAsync<Good, Category, Good>(
            "dbo.spGood_GetById",
            (good, category) =>
            {
                good.Category = category;
                return good;
            },
            splitOn: "CategoryId",
            param: new { Id = id });

        return goods.FirstOrDefault();
    }

    public async Task<IEnumerable<Good>> GetByCategoryId(int cId)
    {
        using var connect = new SqlConnection(_db.GetConnectionString());

        var goods = await connect.QueryAsync<Good, Category, Good>(
            "dbo.spGood_GetByCategoryId",
            (good, category) =>
            {
                good.Category = category;
                return good;
            },
            splitOn: "CategoryId",
            param: new { CategoryId = cId });

        return goods.Distinct().ToList();
    }


}
