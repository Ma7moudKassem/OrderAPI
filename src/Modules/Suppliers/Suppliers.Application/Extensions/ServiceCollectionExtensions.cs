namespace Suppliers.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSuppliersApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}