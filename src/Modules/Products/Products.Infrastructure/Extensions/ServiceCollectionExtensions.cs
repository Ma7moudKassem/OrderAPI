namespace Products.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddProductsInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseContexts<ProductsDbContext>(configuration);

        services.AddTransient<IProductsDbContext, ProductsDbContext>();

        services.AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<IProductUnitOfWork, ProductUnitOfWork>();

        return services;
    }
}