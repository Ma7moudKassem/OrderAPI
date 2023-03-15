namespace Orders.API;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOrdersModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOrdersInfrastructure(configuration)
                .AddOrdersApplication();

        return services;
    }
}