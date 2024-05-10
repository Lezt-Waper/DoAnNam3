using Repository.DbAccess;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data;

public class CategoryData : ICategoryData
{
    private readonly ISqlDataAccess _db;

    public CategoryData(ISqlDataAccess dataAccess)
    {
        this._db = dataAccess;
    }

    public async Task<IEnumerable<Category>> Get() =>
        await _db.LoadData<Category, dynamic>("dbo.spCategory_GetAll", new { });

    public async Task<Category> Get(int Id)
    {
        var result = await _db.LoadData<Category, dynamic>("dbo.spCategory_GetById", new { Id = Id });
        return result.FirstOrDefault();
    }
}
