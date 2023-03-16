namespace Shippers.API;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddShippersModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddShippersApplication()
                .AddShippersInfrastructure(configuration);

        return services;
    }
}
