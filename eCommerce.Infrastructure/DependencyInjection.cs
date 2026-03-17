using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace eCommerce.Infrastructure;
public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services to the depency injection container.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Register your infrastructure services here
        services.AddTransient<IUsersRepository, UsersRepository>();

        // Register DB Context
        services.AddTransient<DapperDbContext>();

        return services;
    }
}
