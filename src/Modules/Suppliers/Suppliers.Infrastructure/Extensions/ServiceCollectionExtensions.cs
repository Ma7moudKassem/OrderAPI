namespace Suppliers.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSuppliersInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseContexts<SuppliersDbContext>(configuration);

        services.AddTransient<ISuppliersDbContext, SuppliersDbContext>();

        services.AddTransient<ISupplierRepository, SupplierRepository>()
                .AddTransient<ISupplierUnitOfWork, SupplierUnitOfWork>();

        return services;
    }
}