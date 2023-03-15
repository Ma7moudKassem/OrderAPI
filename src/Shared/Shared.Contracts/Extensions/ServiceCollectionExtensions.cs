using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
namespace Shared.Contracts;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSharedContracts(this IServiceCollection services, IConfiguration configuration)
    {
        Action<HttpClient> action = c =>
        {
            var userModuleUrl = configuration["BaseUrl"] ?? string.Empty;
            c.BaseAddress = new Uri(userModuleUrl);
        };

        services.AddRefitClient<ICustomerAPI>().ConfigureHttpClient(action);
        services.AddRefitClient<IEmployeeAPI>().ConfigureHttpClient(action);

        return services;
    }
}