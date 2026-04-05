using Microsoft.Extensions.DependencyInjection;
using Core.Application.Services;

namespace Core.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<UserService>();
        services.AddScoped<AuthenticationService>();

        return services;
    }
}