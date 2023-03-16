namespace OrdersDetails.API;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOrdersDetailsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOrdersDetailsApplication()
                .AddOrdersDetailsInfrastructure(configuration);

        return services;
    }
}
