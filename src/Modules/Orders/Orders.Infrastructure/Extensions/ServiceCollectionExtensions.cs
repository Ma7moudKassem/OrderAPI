namespace Orders.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOrdersInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseContexts<OrdersDbContext>(configuration);
        services.AddTransient<IOrdersDbContext, OrdersDbContext>();

        services.AddTransient<IOrderRepository, OrderRepository>()
                .AddTransient<IOrderUnitOfWork, OrderUnitOfWork>();
      
        return services;
    }
}
