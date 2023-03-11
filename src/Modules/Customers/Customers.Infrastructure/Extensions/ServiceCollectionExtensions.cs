namespace Customers.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomersInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ICustomersDbContext, CustomersDbContext>();
        services.AddDatabaseContexts<CustomersDbContext>(configuration);

        services.AddTransient<ICustomerRepository, CustomerRepository>();

        return services;
    }
}
