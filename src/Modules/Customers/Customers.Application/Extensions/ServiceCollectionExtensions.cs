namespace Customers.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomersApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}