namespace Customers.API;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomersModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCustomersInfrastructure(configuration)
                .AddCustomersApplication();

        return services;
    }
}
