using Microsoft.Extensions.Configuration;
using Repository.DbAccess;
using Repository.Data;
using System.Runtime.CompilerServices;
using RSA_Encrypt.RSALib;

namespace WebApplication1.Extensions;

public static class MyConfigServiceCollectionExtension
{
    public static IServiceCollection AddDataService(this IServiceCollection services)
    {
        services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
        services.AddSingleton<ICategoryData, CategoryData>();
        services.AddSingleton<IGoodData, GoodData>();
        services.AddSingleton<IClientData, ClientData>();
        services.AddSingleton<IOrderData, OrderData>();
        services.AddSingleton<IOrderDetailData, OrderDetailData>();
        services.AddSingleton<RSA>(new RSA());
        return services;
    }
}
