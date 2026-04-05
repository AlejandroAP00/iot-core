using Core.Application.Interfaces;
using Core.Infrastructure.Repositories;
using Core.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}