
namespace Repository.DbAccess
{
    public interface ISqlDataAccess
    {
        string GetConnectionString(string connectionID = "Default");
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionID = "Default");
        Task SaveData<T>(string storedProcedure, T parameters, string conncetionId = "Default");
    }
}