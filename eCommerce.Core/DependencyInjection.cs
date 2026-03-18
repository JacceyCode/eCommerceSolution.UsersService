using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;
public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add core services to the depency injection container.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        // Register your core services here
        services.AddTransient<IUsersService, UsersService>();

        // Fluent Validation
        services.AddValidatorsFromAssemblyContaining(typeof(LoginRequestValidator));

        return services;
    }
}
