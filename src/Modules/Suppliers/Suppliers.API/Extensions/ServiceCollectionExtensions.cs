namespace Suppliers.API;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSuppliersModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSuppliersApplication()
                .AddSuppliersInfrastructure(configuration);

        return services;
    }
}
