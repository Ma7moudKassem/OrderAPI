namespace Customers.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomersInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseContexts<CustomersDbContext>(configuration);
        services.AddTransient<ICustomersDbContext, CustomersDbContext>();

        services.AddTransient<ICustomerRepository, CustomerRepository>()
                .AddTransient<ICustomerUnitOfWork, CustomerUnitOfWork>();

        return services;
    }
}
