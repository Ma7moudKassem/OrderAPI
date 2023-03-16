namespace OrdersDetails.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOrdersDetailsInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseContexts<OrdersDetailsDbContext>(configuration);

        services.AddTransient<IOrdersDetailsDbContext, OrdersDetailsDbContext>();

        services.AddTransient<IOrdersDetailRepository, OrdersDetailRepository>()
                .AddTransient<IOrdersDetailUnitOfWork, OrdersDetailUnitOfWork>();

        return services;
    }
}