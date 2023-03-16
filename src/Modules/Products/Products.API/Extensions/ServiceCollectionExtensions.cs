namespace Products.API;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddProductsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddProductsApplication()
                .AddProductsInfrastructure(configuration);

        return services;
    }
}
