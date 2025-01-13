namespace DonatorAPI.Data;

using DonatorAPI.Data.Repositories;
using DonatorAPI.Data.Repositories.IRepository;
using Microsoft.Extensions.DependencyInjection;

public static class DataExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
