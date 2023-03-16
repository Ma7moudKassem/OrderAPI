namespace Products.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddProductsApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}