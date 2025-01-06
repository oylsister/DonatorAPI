namespace DonatorAPI.Data;

using DonatorAPI.Data.Repository;
using DonatorAPI.Data.Repository.IRepository;
using Microsoft.Extensions.DependencyInjection;

public static class DataExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserInfoRepository, UserInfoRepository>();
        services.AddScoped<IPurchaseHistoryRepository, PurchaseHistoryRepository>();

        return services;
    }
}
