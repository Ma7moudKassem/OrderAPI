namespace Shippers.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddShippersInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseContexts<ShippersDbContext>(configuration);

        services.AddTransient<IShippersDbContext, ShippersDbContext>();

        services.AddTransient<IShipperRepository, ShipperRepository>()
                .AddTransient<IShipperUnitOfWork, ShipperUnitOfWork>();

        return services;
    }
}